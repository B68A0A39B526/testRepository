using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.MedicalRecords
{
    public class PrescriptionDTO
    {
        public List<string> Medicine { get; set; }
        public string Status { get; set; }

        public PrescriptionDTO(List<string> med, string status) {
            Medicine = med;
            Status = status;
        }
    }
}
