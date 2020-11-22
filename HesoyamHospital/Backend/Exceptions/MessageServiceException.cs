using Backend.Service.MiscService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class MessageServiceException : Exception
    {
        public MessageServiceException()
        {

        }

        public MessageServiceException(string message) : base(message)
        {

        }

        public MessageServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
