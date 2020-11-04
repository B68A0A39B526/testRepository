using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class FeedbackEmptyException: Exception
    {
        public FeedbackEmptyException()
        {

        }

        public FeedbackEmptyException(string message) : base(message)
        {

        }

        public FeedbackEmptyException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
