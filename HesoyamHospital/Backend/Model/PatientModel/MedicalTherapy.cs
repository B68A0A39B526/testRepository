using Backend.Model.UserModel;
using Backend.Repository.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientModel
{
    public class MedicalTherapy : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private Medicine _medicine;
        public Medicine Medicine { get => _medicine; set { _medicine = value; _medicineId = value.Id; } }

        private long _medicineId;
        public long MedicineId { get => _medicineId; set => _medicineId = value; }

        private TherapyDose _dose;
        public TherapyDose Dose { get => _dose; set { _dose = value; _doseId = value.Id; } }

        private long _doseId;
        public long DoseId { get => _doseId; set => _doseId = value; }

        public MedicalTherapy() { }

        public MedicalTherapy(Medicine medicine, TherapyDose therapyDose)
        {
            _medicine = medicine;
            _medicineId = medicine.Id;
            _dose = therapyDose;
            _doseId = therapyDose.Id;
        }

        public override bool Equals(object obj)
        {
            var mt = obj as MedicalTherapy;
            return mt != null &&
                   _id == mt._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;
    }
}
