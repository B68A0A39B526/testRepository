using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientModel
{
    public class DiseaseMedicine
    {
        public long DiseaseId { get; set; }
        public Disease Disease { get => Disease; set { Disease = value; DiseaseId = value.Id; } }
        public long MedicineId { get; set; }
        public Medicine Medicine { get => Medicine; set { Medicine = value; MedicineId = value.Id; } }
        
        public DiseaseMedicine() { }
        public DiseaseMedicine(Disease d, Medicine m)
        {
            Disease = d;
            DiseaseId = d.Id;
            Medicine = m;
            MedicineId = m.Id;
        }
    }
}
