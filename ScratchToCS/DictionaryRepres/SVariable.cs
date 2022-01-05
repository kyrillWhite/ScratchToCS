using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public class SVariable
    {
        public string Name;
        public dynamic Value;

        public SVariable(string name, dynamic value)
        {
            Name = name;
            Value = value;
        }
    }
}
