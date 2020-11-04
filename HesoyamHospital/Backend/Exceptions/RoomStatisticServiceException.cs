using System;
using System.Runtime.Serialization;

namespace Backend.Service.HospitalManagementService
{
    [Serializable]
    internal class RoomStatisticServiceException : Exception
    {
        public RoomStatisticServiceException()
        {
        }

        public RoomStatisticServiceException(string message) : base(message)
        {
        }

        public RoomStatisticServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoomStatisticServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}