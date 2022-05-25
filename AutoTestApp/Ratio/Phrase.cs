using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoTestApp
{
    public class Phrase
    {
        public List<string> Words { get; set; }
        public int Digit { get; set; }
        public bool DigitFromWord { get; set; }
        public bool BracketDigit { get; set; }

        private int WordToNum(string word)
        {
            var roots = new List<string>(new[]{ "перв", "втор", "трет", "четв", "пят", "шест", "седьм", "восьм", "девят" });
            return roots.FindIndex(w => word.Contains(w));
        }


        public Phrase(string name)
        {
            if (name == "Проект Scratch (2).sb3")
            {
                var ad = 0;
            }
            DigitFromWord = false;
            BracketDigit = false;
            Digit = -1;
            name = name.ToLower();
            name = Regex.Replace(name, @"\.sb3", " ");
            name = Regex.Replace(name, @"[^а-яА-Яa-zA-Z0-9\(\)]", " ");
            var namesD = Regex.Split(name, @"(?<=\D)(?=\(\d)|(?<=\d\))(?=\D)|(?<=[^\d(])(?=\d)|(?<=\d)(?=[^\d)])");
            var names = new List<string>();
            foreach(var _name in namesD)
            {
                var namesS = _name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                names.AddRange(namesS);
            }
            for (int i = 0; i < names.Count; i++)
            {
                if (Digit == -1)
                {
                    if (char.IsDigit(names[i][0]) || 
                        (names[i].Length > 2 && names[i][0] == '(' && char.IsDigit(names[i][1])))
                    {
                        if ((names[i].Length > 2 && names[i].First() == '(' && names[i].Last() == ')'))
                        {
                            BracketDigit = true;
                        }
                        names[i] = Regex.Replace(names[i], @"[()]", "");
                        int _digit = -1;
                        int.TryParse(names[i], out _digit);
                        Digit = _digit;
                    }
                    else
                    {
                        var num = WordToNum(names[i]);
                        if (num != -1)
                        {
                            DigitFromWord = true;
                            Digit = num + 1;
                        }
                    }
                }
            }
            names.RemoveAll(s => char.IsDigit(s[0]) || 
                (s.Length > 2 && s[0] == '(' && char.IsDigit(s[1])) || 
                WordToNum(s) != -1 || s.Contains("задани") || s.Contains("задач") || 
                s == "проект" || s == "scratch");
            Words = names;
        }
    }
}
