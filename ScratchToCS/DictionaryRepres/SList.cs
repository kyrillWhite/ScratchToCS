using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public class SList
    {
        public string Name;
        public List<dynamic> Values;

        public SList(string name, List<dynamic> values)
        {
            Name = name;
            Values = values;
        }

        public string GetString()
        {
            return Values.Aggregate((x, y) => $"{x} {y}");
        }
    }
}
