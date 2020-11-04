using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class LocationCountryException : Exception
    {
        public LocationCountryException()
        {

        }

        public LocationCountryException(string message) : base(message)
        {

        }

        public LocationCountryException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
