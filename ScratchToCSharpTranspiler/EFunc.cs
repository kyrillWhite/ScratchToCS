using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SToCSTranspiler
{
    public class EFunc
    {
        public ParameterExpression Function;
        public ParameterExpression Parameter;
        public SMutation PrototypeMutation;

        public EFunc(ParameterExpression function, ParameterExpression parameter, SMutation prototypeMutation)
        {
            Function = function;
            Parameter = parameter;
            PrototypeMutation = prototypeMutation;
        }
    }
}
