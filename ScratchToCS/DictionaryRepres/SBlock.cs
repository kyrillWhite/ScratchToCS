using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public class SBlock
    {
        public Opcode Opcode;
        public string NextId;
        public string ParentId;
        public Dictionary<string, SInput> Inputs;
        public List<SField> Fields;
        public SMutation Mutation;

        public SBlock(Opcode opcode, string nextId, string parentId, Dictionary<string, SInput> inputs, List<SField> fields, SMutation mutation)
        {
            Opcode = opcode;
            NextId = nextId;
            ParentId = parentId;
            Inputs = inputs;
            Fields = fields;
            Mutation = mutation;
        }
    }
}
