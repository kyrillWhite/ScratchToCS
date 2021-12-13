using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SToCSTranspiler
{
    public enum TypeOfInput
    {
        Block = 0,
        Number = 4,
        String = 10,
        Variable = 12,
        List = 13
    }

    public class SInput
    {
        public bool Shadow;
        public dynamic Value;
        public TypeOfInput Type;

        public SInput(bool shadow, dynamic value, TypeOfInput type)
        {
            Shadow = shadow;
            Value = value;
            Type = type;
        }
    }
}
