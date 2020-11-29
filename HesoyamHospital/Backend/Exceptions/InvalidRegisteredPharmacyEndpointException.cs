using System;

namespace Backend.Exceptions
{
    public class InvalidRegisteredPharmacyEndpointException : Exception
    {
        public InvalidRegisteredPharmacyEndpointException()
        {

        }

        public InvalidRegisteredPharmacyEndpointException(string message) : base(message)
        {

        }

        public InvalidRegisteredPharmacyEndpointException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
