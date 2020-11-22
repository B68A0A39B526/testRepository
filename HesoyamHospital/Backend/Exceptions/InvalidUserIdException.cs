using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class InvalidUserIdException : Exception
    {
        public InvalidUserIdException()
        {

        }
        public InvalidUserIdException(string message) : base(message)
        {

        }

        public InvalidUserIdException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
