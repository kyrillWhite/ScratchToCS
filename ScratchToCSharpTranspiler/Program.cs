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
        static void Main(string[] args)
        {
            string scratchPath;
            string inputPath;
            while (true)
            {
                Console.Write("Введите путь до файла Scratch программы формата .sb3\nScratch: ");
                scratchPath = Console.ReadLine();
                scratchPath = scratchPath.Trim('\"');
                if (!(File.Exists(scratchPath)))
                {
                    Console.WriteLine("Файл не найден.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Введите путь до файла INPUT.txt (Данные читаются построчно)\nINPUT: ");
                inputPath = Console.ReadLine();
                inputPath = inputPath.Trim('\"');
                if (!(File.Exists(inputPath)))
                {
                    Console.WriteLine("Файл не найден.");
                    continue;
                }
                break;
            }

            var input = new List<object>();
            string s;
            using (var r = new StreamReader(inputPath))
            {
                while ((s = r.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }

            Transpiler.ChangeSpecValues();
            var json = Transpiler.ScratchToJson(scratchPath);
            var dScratch = Transpiler.JsonToDScratch(json);
            var funcExpression = Transpiler.DScratchToExpression(dScratch);
            var compiledExpression = Transpiler.Compile(funcExpression);
            var (outputData, error) = Transpiler.Run(TimeSpan.FromSeconds(2), compiledExpression, input);

            switch (error)
            {
                case 1:
                    Console.WriteLine("Время выполнения программы превысило заданное ограничение (2 сек).");
                    Console.ReadKey();
                    return;
                case 2:
                    Console.WriteLine("Не был обнаружен инициализирующий блок \"Когда флаг нажат\".");
                    Console.ReadKey();
                    return;
            }

            using (var w = new StreamWriter("OUTPUT.txt"))
            {
                outputData.ForEach(od => w.WriteLine(od));
            }
            Console.WriteLine("Готово");
            Console.WriteLine($"Выходной файл: {Directory.GetCurrentDirectory()}\\OUTPUT.txt");
            Console.ReadKey();
        }
    }
}