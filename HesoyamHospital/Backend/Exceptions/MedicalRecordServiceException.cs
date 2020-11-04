using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    [Serializable]
    class MedicalRecordServiceException : Exception
    {
        public MedicalRecordServiceException()
        {
        }

        public MedicalRecordServiceException(string message) : base(message)
        {
        }

        public MedicalRecordServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MedicalRecordServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
