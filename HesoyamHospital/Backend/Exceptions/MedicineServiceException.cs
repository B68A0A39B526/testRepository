using Backend.Service.HospitalManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    class MedicineServiceException : Exception
    {
        public MedicineServiceException()
        {

        }

        public MedicineServiceException(string message) : base(message)
        {

        }

        public MedicineServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
