using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class DiseaseServiceException : Exception
    {
        public DiseaseServiceException()
        {

        }

        public DiseaseServiceException(string message) : base(message)
        {

        }

        public DiseaseServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
