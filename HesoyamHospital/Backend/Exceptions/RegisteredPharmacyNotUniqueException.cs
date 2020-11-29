using System;

namespace Backend.Exceptions
{
    public class RegisteredPharmacyNameNotUniqueException : Exception
    {
        public RegisteredPharmacyNameNotUniqueException()
        {

        }

        public RegisteredPharmacyNameNotUniqueException(string message) : base(message)
        {

        }

        public RegisteredPharmacyNameNotUniqueException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
