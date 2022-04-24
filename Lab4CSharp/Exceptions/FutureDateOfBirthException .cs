using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp.Exceptions
{
    class FutureDateOfBirthException : Exception
    {

        public FutureDateOfBirthException()
        {
        }

        public FutureDateOfBirthException(string message)
            : base(message)
        {
        }

        public FutureDateOfBirthException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
