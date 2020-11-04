using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class DoctorServiceException : Exception
    {
        public DoctorServiceException()
        {

        }

        public DoctorServiceException(string message) : base(message)
        {

        }

        public DoctorServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
