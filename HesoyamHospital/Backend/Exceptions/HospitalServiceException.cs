using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class HospitalServiceException : Exception
    {
        public HospitalServiceException()
        {

        }

        public HospitalServiceException(string message) : base(message)
        {

        }

        public HospitalServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
