using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp.Exceptions
{
    class FarDateOfBirthException : Exception
    {
        public FarDateOfBirthException()
        {
        }

        public FarDateOfBirthException(string message)
            : base(message)
        {
        }

        public FarDateOfBirthException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
