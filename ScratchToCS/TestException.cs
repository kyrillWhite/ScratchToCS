using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public class TestException : Exception
    {
        public TestException() { }

        public TestException(string message) : base(message) { }

        public TestException(string message, Exception inner) : base(message, inner) { }
    }
}
