using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapter.PharmacyMock
{
    public class Pharmacy
    {
        public string PharmacyName { get; set; }
        public Pharmacy(string pharmacyName)
        {
            PharmacyName = pharmacyName;
        }
        public Pharmacy() { }
    }
}
