using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class Survey : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Section StaffSection { get; set; }
        public virtual Section DoctorSection { get; set; }
        public virtual Section HygieneSection { get; set; }
        public virtual Section EquipmentSection { get; set; }

        public Survey()
        {
        }

        public Survey(long id) {

            Id = id;

        }

        public Survey(long id, Doctor doctor, Section staffSection, Section doctorSection, Section hygieneSection, Section equipmentSection)
        {

            Id = id;
            Doctor = doctor;
            StaffSection = staffSection;
            DoctorSection = doctorSection;
            HygieneSection = hygieneSection;
            EquipmentSection = equipmentSection;
        }

        public long GetId() => Id;
        public void SetId(long id) => Id = id;
    }
}
