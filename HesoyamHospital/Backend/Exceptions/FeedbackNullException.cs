using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class FeedbackNullException: Exception
    {
        public FeedbackNullException()
        {

        }

        public FeedbackNullException(string message) : base(message)
        {

        }

        public FeedbackNullException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
