using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public class SMutation
    {
        public string Proccode;
        public List<string> ArgumentIds;
        public List<string> ArgumentNames;

        public SMutation(string proccode, List<string> argumentIds, List<string> argumentNames)
        {
            Proccode = proccode;
            ArgumentIds = argumentIds;
            ArgumentNames = argumentNames;
        }
    }
}
