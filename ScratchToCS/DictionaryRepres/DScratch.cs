using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public class DScratch
    {
        public Dictionary<string, SVariable> Variables;
        public Dictionary<string, SList> Lists;
        public Dictionary<string, SBlock> Blocks;

        public DScratch(Dictionary<string, SVariable> variables, Dictionary<string, SList> lists, Dictionary<string, SBlock> blocks)
        {
            Variables = variables;
            Lists = lists;
            Blocks = blocks;
        }
    }
}
