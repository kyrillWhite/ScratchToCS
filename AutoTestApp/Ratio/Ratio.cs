using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestApp
{
    public class Ratio
    {
        private static float digitCoefficient = 100;
        private static float wordDigitCoefficient = 60;
        private static float bracketDigitCoefficient = 20;
        private static float wordCoefficient = 40;

        public float MaxCoefficient { get; } = digitCoefficient + wordCoefficient;

        private Dictionary<int, Phrase> _solutionNames;
        private Dictionary<int, Phrase> _problemNames;

        private float CompareWords(string str1, string str2)
        {
            var a = (float)str1.Length;
            var b = (float)str2.Length;
            var c = (float)str1.Intersect(str2).Count();
            return c / (a + b - c);
        }

        private float ComparePhrases(Phrase phr1, Phrase phr2)
        {
            var acc = 0f;
            foreach(var word1 in phr1.Words)
            {
                foreach (var word2 in phr2.Words)
                {
                    acc += CompareWords(word1, word2);
                }
            }
            var wc = phr1.Words.Count * phr2.Words.Count;
            var w = wc == 0 ? 0 : ((acc / wc) * wordCoefficient);
            var d = 0f;
            if (phr1.Digit == phr2.Digit && phr1.Digit != -1 && phr2.Digit != -1)
            {
                if (phr1.BracketDigit || phr2.BracketDigit)
                {
                    d = bracketDigitCoefficient;
                }
                else if (phr1.DigitFromWord || phr2.DigitFromWord)
                {
                    d = wordDigitCoefficient;
                }
                else
                {
                    d = digitCoefficient;
                }
            }
            return w + d;
        }

        public Ratio(List<Solution> solutions, List<Problem> problems)
        {
            _solutionNames = new Dictionary<int, Phrase>();
            _problemNames = new Dictionary<int, Phrase>();
            foreach (var solution in solutions)
            {
                _solutionNames.Add(solution.Id, new Phrase(solution.FileName));
            }
            foreach (var problem in problems)
            {
                _problemNames.Add(problem.Id, new Phrase(problem.Name));
            }
        }

        public Dictionary<int, (int, float)> Сorrelate(int participantId)
        {
            var probsols = new Dictionary<int, (int, float)>();
            using var db = new TSystemContext(); 
            var problems = db.Problems.ToList();
            var solutions = db.Participants.Include(p => p.Solutions).FirstOrDefault(p => p.Id == participantId).Solutions;
            var coefficients = new Dictionary<(int, int), float>();

            foreach (var problem in problems)
            {
                foreach (var solution in solutions)
                {
                    coefficients.Add((problem.Id, solution.Id), 
                        ComparePhrases(_problemNames[problem.Id], _solutionNames[solution.Id]));
                }
            }
            var pc = problems.Count;
            for (int p = 0; p < pc; p++)
            {
                var maxCoef = -1f;
                var problemId = 0;
                var solutionsId = 0;

                foreach (var problem in problems)
                {
                    foreach (var solution in solutions)
                    {
                        if (coefficients[(problem.Id, solution.Id)] > maxCoef)
                        {
                            problemId = problem.Id;
                            solutionsId = solution.Id;
                            maxCoef = coefficients[(problem.Id, solution.Id)];
                        }
                    }
                }
                if (maxCoef != -1f) {
                    probsols.Add(problemId, (solutionsId, maxCoef));
                    problems.RemoveAll(p => p.Id == problemId);
                    solutions.RemoveAll(s => s.Id == solutionsId);
                }
            }
            return probsols;
        }

        public Dictionary<int, float> CurrentСorrelate(List<Solution> solutions)
        {
            var solidcoefs = new Dictionary<int, float>();
            //using var db = new TSystemContext();
            //var solutions = db.Participants.Include(p => p.Solutions).FirstOrDefault(p => p.Id == participantId).Solutions;

            foreach (var solution in solutions)
            {
                solidcoefs.Add(solution.Id,
                    ComparePhrases(_problemNames[solution.ProblemId], _solutionNames[solution.Id]));
            }

            return solidcoefs;
        }
    }
}
