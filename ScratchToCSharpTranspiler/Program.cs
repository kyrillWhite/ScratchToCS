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
            string outputPath;
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
                Console.Write("Введите путь до файла INPUT.txt (Данные читаются построково)\nINPUT: ");
                inputPath = Console.ReadLine();
                inputPath = inputPath.Trim('\"');
                if (!(File.Exists(inputPath)))
                {
                    Console.WriteLine("Файл не найден.");
                    continue;
                }
                break;
            }
            Console.Write("Введите путь до директории файла OUTPUT.txt\nOUTPUT: ");
            outputPath = Console.ReadLine();
            outputPath = outputPath.Trim('\"');
            if (!(Directory.Exists(outputPath)))
            {
                Console.WriteLine("Директория не найдена. Файл будет сохранен в текущей.");
                outputPath = "";
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
            var json  = Transpiler.ScratchToJson("C:/Users/kirill/Desktop/Test scratch/Scratch Project.sb3");
            var dScratch = Transpiler.JsonToDScratch(json);
            var funcExpression = Transpiler.DScratchToExpression(dScratch);
            var compiledExpression = funcExpression.Compile();
            var outputData = compiledExpression(input);

            using (var w = new StreamWriter(outputPath + "OUTPUT.txt"))
            {
                outputData.ForEach(od => w.WriteLine(od));
            }

            Console.WriteLine("Готово");
        }
    }
}
