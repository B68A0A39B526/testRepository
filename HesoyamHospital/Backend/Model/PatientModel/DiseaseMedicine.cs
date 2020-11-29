using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientModel
{
    public class DiseaseMedicine
    {
        public long DiseaseId { get; set; }

        private Disease _disease;
        public virtual Disease Disease { get => _disease; set { _disease = value; DiseaseId = value.Id; } }
        public long MedicineId { get; set; }

        private Medicine _medicine;
        public virtual Medicine Medicine { get => _medicine; set { _medicine = value; MedicineId = value.Id; } }
        
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
