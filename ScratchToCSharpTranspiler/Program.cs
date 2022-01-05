using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting;

namespace SToCSTranspiler
{
    class Program
    {
        static List<object> ReadFile(string path)
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

        static void Main(string[] args)
        {
            var programsPath = "";
            var inputPath = "";
            var outputPath = "";

            while (true)
            {
                Console.Write("Введите путь до директории с файлами Scratch программ формата .sb3\nДиректория с программами: ");
                programsPath = Console.ReadLine();
                programsPath = programsPath.Trim('\"');
                if (!(Directory.Exists(programsPath)))
                {
                    Console.WriteLine("Указанная директория не найдена.");
                    programsPath = "";
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Введите путь до файла с входными данными (Данные читаются построчно)\nINPUT: ");
                inputPath = Console.ReadLine();
                inputPath = inputPath.Trim('\"');
                if (!(File.Exists(inputPath)))
                {
                    Console.WriteLine("Файл не найден.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Введите путь до файла с эталонными выходными данными (Данные читаются построчно)\nOUTPUT: ");
                outputPath = Console.ReadLine();
                outputPath = outputPath.Trim('\"');
                if (!(File.Exists(outputPath)))
                {
                    Console.WriteLine("Файл не найден.");
                    continue;
                }
                break;
            }

            var programs = Directory.GetFiles(programsPath, "*.sb3");
            var input = ReadFile(inputPath);
            var output = ReadFile(outputPath);
            var resOutput = "";

            foreach (var programPath in programs)
            {
                var fileName = Path.GetFileNameWithoutExtension(programPath);
                resOutput += $"{fileName};";
                Console.Write($"{fileName}: ");
                try
                {
                    Transpiler.ChangeSpecValues();
                    var json = Transpiler.ScratchToJson(programPath);
                    var dScratch = Transpiler.JsonToDScratch(json);
                    var funcExpression = Transpiler.DScratchToExpression(dScratch);
                    var compiledExpression = Transpiler.Compile(funcExpression);
                    var (outputData, error) = Transpiler.Run(TimeSpan.FromSeconds(2), compiledExpression, new List<object>(input));

                    switch (error)
                    {
                        case 0:
                            Console.WriteLine($"Ответ {(outputData.SequenceEqual(output) ? "верный" : "неверный")}. ");
                            break;
                        case 1:
                            Console.WriteLine("Время выполнения программы превысило заданное ограничение (2 сек).");
                            break;
                        case 2:
                            Console.WriteLine("Не был обнаружен инициализирующий блок \"Когда флаг нажат\".");
                            break;
                    }
                    outputData.ForEach(od => resOutput += $"{od};");
                    resOutput = resOutput.Remove(resOutput.Length - 1);
                    resOutput += "\n";
                }
                catch
                {
                    Console.WriteLine("Непредвиденная ошибка.");
                }
            }
            using (var w = new StreamWriter($"OUTPUT.csv"))
            {
                w.Write(resOutput);
            }
            Console.WriteLine($"Выходной файл: {Directory.GetCurrentDirectory()}\\OUTPUT.csv\n");
            Console.WriteLine("Нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
