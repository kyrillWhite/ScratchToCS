using ScratchToCS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting;

namespace TestApp
{
    class Program
    {
        static double _maxTime = 0.5;
        static List<object> ReadFile(string path)
        {
            try
            {
                var res = new List<object>();
                string s;
                using (var r = new StreamReader(path))
                {
                    while ((s = r.ReadLine()) != null)
                    {
                        res.Add(s);
                    }
                }
                return res;
            }
            catch
            {
                return new List<object>();
            }
        }

        static void Main(string[] args)
        {
            var programsPath = "";
            var testsPath = "";

            while (true)
            {
                Console.Write("Введите путь до директории с файлами Scratch программ формата .sb3\nДиректория с программами: ");
                programsPath = Console.ReadLine();
                programsPath = programsPath.Trim('\"');
                if (!(Directory.Exists(programsPath)))
                {
                    Console.WriteLine("Указанная директория не найдена.\n");
                    programsPath = "";
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Введите путь до директории с тестами. (Один тест - одна папка с файлами input.txt и output.txt)\nДиректория с тестами: ");
                testsPath = Console.ReadLine();
                testsPath = testsPath.Trim('\"');
                if (!(Directory.Exists(testsPath)))
                {
                    Console.WriteLine("Указанная директория не найдена.\n");
                    continue;
                }
                break;
            }
            Directory.CreateDirectory("OUTPUT");
            var tests = Directory.GetDirectories(testsPath);

            Console.WriteLine();

            var programs = Directory.GetFiles(programsPath, "*.sb3");
            foreach (var programPath in programs)
            {
                var fileName = Path.GetFileNameWithoutExtension(programPath);
                Console.Write($"{fileName}\n");
                var resOutput = "";

                foreach (var test in tests)
                {
                    var testName = Path.GetFileNameWithoutExtension(test);
                    var input = ReadFile($"{test}\\input.txt");
                    var output = ReadFile($"{test}\\output.txt");
                    resOutput += $"{testName};";
                    Console.Write($"{testName}: ");

                    try
                    {
                        Transpiler.ChangeSpecValues();
                        var json = Transpiler.ScratchToJson(programPath);
                        var dScratch = Transpiler.JsonToDScratch(json);
                        var funcExpression = Transpiler.DScratchToExpression(dScratch);
                        var compiledExpression = Transpiler.Compile(funcExpression);
                        var outputData = Transpiler.Run(TimeSpan.FromSeconds(_maxTime), compiledExpression, new List<object>(input));

                        Console.WriteLine($"Ответ {(outputData.SequenceEqual(output) ? "верный" : "неверный")}. ");
                        outputData.ForEach(od => resOutput += $"{od};");
                        resOutput = resOutput.Remove(resOutput.Length - 1);
                        resOutput += "\n";
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e is TestException ? 
                            e.Message : "Непредвиденная ошибка.");
                    }
                }
                using (var w = new StreamWriter($"OUTPUT\\{fileName}.txt"))
                {
                    w.Write(resOutput);
                }
                Console.WriteLine($"Выходной файл: {Directory.GetCurrentDirectory()}\\OUTPUT\\{fileName}.txt\n");
            }
            Console.WriteLine("Тестировние завершено. Нажмите любую кнопку, чтобы выйти...");
            Console.ReadKey();
        }
    }
}