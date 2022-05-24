using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using ScratchToCS;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace AutoTestApp
{
    public static class RunTests
    {
        static double _maxTime = 0.5;
        private static List<object> StringToList(string text)
        {
            return new List<object>((text ?? "").Split("\r\n", StringSplitOptions.RemoveEmptyEntries));
        }

        public static void Run(List<Solution> solutions, BackgroundWorker bwMain)
        {
            using (var db = new TSystemContext())
            {
                db.TestResults.RemoveRange(solutions.SelectMany(s => s.TestResults));
                solutions.ForEach(s => { s.TestResults.Clear(); s.TranslationError = ""; s.Warnings = ""; s.TestPassed = 0; });
                db.SaveChanges();
            }
            // Транспилирование
            var completed = 0;
            var transpiledSolutions = new Dictionary<Solution, Expression<Func<CancellationToken, List<object>, List<object>>>>();
            Parallel.ForEach(solutions, (solution) =>
            {
                bwMain.ReportProgress((int)(0.3 * completed * 100 / solutions.Count), "Транспиляция");
                try
                {
                    var dScratch = Transpiler.JsonToDScratch(solution.SolutionFile);
                    var funcExpression = Transpiler.DScratchToExpression(dScratch);
                    transpiledSolutions[solution] = funcExpression;
                }
                catch (Exception e)
                {
                    solution.TranslationError = $"🚫{e.Message}";
                }
                solution.Warnings = string.Join("\r\n", WarningsLogger.PopAllWarnings());
                Interlocked.Increment(ref completed);
            });
            // Компилирование
            completed = 0;
            var compiledSolutions = new Dictionary<Solution, Func<CancellationToken, List<object>, List<object>>>();
            Parallel.ForEach(transpiledSolutions, (solutionPair) =>
            {
                bwMain.ReportProgress((int)(30 + 0.1 * completed * 100 / solutions.Count), "Компиляция");
                try
                {
                    var func = Transpiler.Compile(solutionPair.Value);
                    compiledSolutions[solutionPair.Key] = func;
                }
                catch (Exception e)
                {
                    solutionPair.Key.TranslationError = $"🚫{e.Message}";
                }
                Interlocked.Increment(ref completed);
            });
            //Тестирование
            completed = 0;
            Parallel.ForEach(compiledSolutions, (solutionPair) =>
            {
                bwMain.ReportProgress((int)(40 + 0.6 * completed * 100 / solutions.Count), "Тестирование");
                if (solutionPair.Key != null)
                {
                    var solution = solutionPair.Key;
                    var func = solutionPair.Value;
                    foreach (var test in solution.Problem.Tests)
                    {
                        var testResult = new TestResult { Solution = solution, Test = test };
                        try
                        {
                            var inputList = StringToList(test.InputData);
                            var outputList = StringToList(test.OutputData);
                            var outputListRes = Transpiler.Run(TimeSpan.FromSeconds(_maxTime),
                                func, new List<object>(inputList));
                            if (Enumerable.SequenceEqual(outputList, outputListRes))
                            {
                                testResult.IsCorrect = true;
                                solution.TestPassed++;
                            }
                            testResult.ResultOutputData = string.Join("\r\n", outputListRes);
                        }
                        catch (Exception e)
                        {
                            testResult.ErrorText = e.Message;
                        }
                        solution.TestResults.Add(testResult);
                    }
                }
                Interlocked.Increment(ref completed);
            });

            using (var db = new TSystemContext())
            {
                foreach (var solution in solutions)
                {
                    db.Solutions.Attach(solution);
                    db.Entry(solution).Property("Warnings").IsModified = true;
                    db.Entry(solution).Property("TranslationError").IsModified = true;
                    db.Entry(solution).Property("TestPassed").IsModified = true;
                    db.TestResults.AddRange(solution.TestResults);
                }
                db.SaveChanges();
            }
        }
    }
}
