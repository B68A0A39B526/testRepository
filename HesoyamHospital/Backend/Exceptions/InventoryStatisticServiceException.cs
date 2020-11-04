using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class InventoryStatisticServiceException : Exception
    {
        public InventoryStatisticServiceException()
        {

        }

        public InventoryStatisticServiceException(string message) : base(message)
        {

        }

        public InventoryStatisticServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
