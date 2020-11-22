using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class LocationCityException: Exception
    {
        public LocationCityException()
        {

        }

        public LocationCityException(string message) : base(message)
        {

        }

        public LocationCityException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
