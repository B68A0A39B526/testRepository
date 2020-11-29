using Backend.Repository.Abstract;

namespace Backend.Model.PatientModel
{
    public class MedicalTherapy : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual TherapyDose Dose { get; set; }

        public MedicalTherapy() { }

        public MedicalTherapy(Medicine medicine, TherapyDose therapyDose)
        {
            Medicine = medicine;
            Dose = therapyDose;
        }

        public override bool Equals(object obj)
        {
            var mt = obj as MedicalTherapy;
            return mt != null &&
                   Id == mt.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public bool containsMedicineWithName(string name)
            => Medicine.Name.ToLower().Contains(name.ToLower());
    }
}
