using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientModel
{
    public class SingleTherapyDose : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private TherapyTime _therapyTime;
        public TherapyTime TherapyTime { get => _therapyTime; set => _therapyTime = value; }

        private double _quantity;
        public double Quantity { get => _quantity; set => _quantity = value; }

        public SingleTherapyDose()
        {

        }

        public SingleTherapyDose(TherapyTime therapyTime, double quantity)
        {
            _therapyTime = therapyTime;
            _quantity = quantity;
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            var dose = obj as SingleTherapyDose;
            return dose != null &&
                   _id == dose._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}
