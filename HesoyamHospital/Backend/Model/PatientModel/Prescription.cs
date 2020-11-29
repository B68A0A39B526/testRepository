// File:    Prescription.cs
// Author:  nikola
// Created: 21. maj 2020 15:43:46
// Purpose: Definition of Class Prescription

using Backend.Repository.Abstract;
using System.Collections.Generic;
using Backend.Model.UserModel;
using System;
using Backend.Util;

namespace Backend.Model.PatientModel
{
    public class Prescription : Document, IIdentifiable<long>
    {
        public PrescriptionStatus Status { get; set; }

        private List<MedicalTherapy> _medicalTherapies;
        public virtual List<MedicalTherapy> MedicalTherapies
        {
            get
            {
                if (_medicalTherapies == null)
                    _medicalTherapies = new List<MedicalTherapy>();
                return _medicalTherapies;
            }
            set
            {
                RemoveAllMedicine();
                if (value != null)
                {
                    foreach (MedicalTherapy mt in value)
                        AddMedicine(mt);
                }
            }
        }

        public Prescription(long id)
        {
            Id = id;
        }
        public Prescription(long id, PrescriptionStatus status, Doctor doctor, List<MedicalTherapy> medicalTherapies)
        {
            Id = id;
            Status = status;
            Doctor = doctor;
            MedicalTherapies = medicalTherapies;
        }

        public Prescription(PrescriptionStatus status, Doctor doctor, List<MedicalTherapy> medicalTherapies)
        {
            Status = status;
            Doctor = doctor;
            MedicalTherapies = medicalTherapies;
        }

        public Prescription(List<MedicalTherapy> medicalTherapies)
        {
            Status = PrescriptionStatus.ACTIVE;
            MedicalTherapies = medicalTherapies;
        }

        public Prescription(PrescriptionStatus status, Doctor doctor, List<MedicalTherapy> medicalTherapies, Diagnosis diagnosis, Patient patient)
        {
            Status = status;
            Doctor = doctor;
            MedicalTherapies = medicalTherapies;
            Diagnosis = diagnosis;
            Patient = patient;
        }

        public void AddMedicine(MedicalTherapy mt)
      {
         if (mt == null)
            return;
         if (this.MedicalTherapies == null)
            this.MedicalTherapies = new List<MedicalTherapy>();
         if (!this.MedicalTherapies.Contains(mt))
            this.MedicalTherapies.Add(mt);
      }
      
      public void RemoveMedicine(MedicalTherapy mt)
      {
         if (mt == null)
            return;
         if (this.MedicalTherapies != null && this.MedicalTherapies.Contains(mt))
            this.MedicalTherapies.Remove(mt);
      }
      
      public void RemoveAllMedicine()
      {
         if (MedicalTherapies != null)
            MedicalTherapies.Clear();
      }

        public long GetId()
            => Id;

        public void SetId(long id)
            => Id = id;

        public override bool Equals(object obj)
        {
            var prescription = obj as Prescription;
            return prescription != null &&
                   Id == prescription.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public override bool meetsCriteria(DocumentSearchCriteria criteria)
        {
            if (!base.meetsCriteria(criteria)) return false;
            foreach (MedicalTherapy therapy in MedicalTherapies)
                if (!therapy.containsMedicineWithName(criteria.MedicineName)) return false;
            return true;
        }
        public string StatusToString(PrescriptionStatus s) {
            if (s == PrescriptionStatus.EXPIRED)
            {
                return "expired";
            }
            else if (s == PrescriptionStatus.ACTIVE)
            {
                return "active";
            }
            else if (s == PrescriptionStatus.USED)
            {
                return "used";
            }
            else {
                return "deactivated";
            }
            
        }
    }
}