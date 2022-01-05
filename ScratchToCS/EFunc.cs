using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public class EFunc
    {
        public ParameterExpression Function;
        public ParameterExpression Parameter;
        public ParameterExpression ReturnVariable;
        public LabelTarget CurrentReturnTarget;
        public SMutation PrototypeMutation;

        public EFunc(ParameterExpression function,
            ParameterExpression parameter,
            ParameterExpression returnVariable,
            LabelTarget currentReturnTarget,
            SMutation prototypeMutation)
        {
            Function = function;
            Parameter = parameter;
            ReturnVariable = returnVariable;
            CurrentReturnTarget = currentReturnTarget;
            PrototypeMutation = prototypeMutation;
        }
    }
}
