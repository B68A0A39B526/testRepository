using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientModel
{
    public class SingleTherapyDose : IIdentifiable<long>
    {
        public long Id { get; set; }
        public TherapyTime TherapyTime { get; set; }
        public double Quantity { get; set; }

        public SingleTherapyDose()
        {

        }

        public SingleTherapyDose(TherapyTime therapyTime, double quantity)
        {
            TherapyTime = therapyTime;
            Quantity = quantity;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            var dose = obj as SingleTherapyDose;
            return dose != null &&
                   Id == dose.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}
