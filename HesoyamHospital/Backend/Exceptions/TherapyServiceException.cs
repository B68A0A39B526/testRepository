using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class TherapyServiceException : Exception
    {
        public TherapyServiceException()
        {
        }

        public TherapyServiceException(string message) : base(message)
        {
        }

        public TherapyServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
