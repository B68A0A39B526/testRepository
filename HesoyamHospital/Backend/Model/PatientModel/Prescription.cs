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
            Type = DocumentType.PRESCRIPTION;
        }
        public Prescription(long id, PrescriptionStatus status, Doctor doctor, List<MedicalTherapy> medicalTherapies)
        {
            Id = id;
            Status = status;
            Doctor = doctor;
            MedicalTherapies = medicalTherapies;
            Type = DocumentType.PRESCRIPTION;
        }

        public Prescription(PrescriptionStatus status, Doctor doctor, List<MedicalTherapy> medicalTherapies)
        {
            Status = status;
            Doctor = doctor;
            MedicalTherapies = medicalTherapies;
            Type = DocumentType.PRESCRIPTION;
        }

        public Prescription(List<MedicalTherapy> medicalTherapies)
        {
            Status = PrescriptionStatus.ACTIVE;
            MedicalTherapies = medicalTherapies;
            Type = DocumentType.PRESCRIPTION;
        }

        public Prescription(PrescriptionStatus status, Doctor doctor, List<MedicalTherapy> medicalTherapies, Diagnosis diagnosis, Patient patient)
        {
            Status = status;
            Doctor = doctor;
            MedicalTherapies = medicalTherapies;
            Diagnosis = diagnosis;
            Patient = patient;
            Type = DocumentType.PRESCRIPTION;
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
            if (MedicalTherapies.Count == 0 && !criteria.MedicineName.Equals("")) return false;
            foreach (MedicalTherapy therapy in MedicalTherapies)
                if (!therapy.containsMedicineWithName(criteria.MedicineName)) return false;
            return true;
        }

        public override bool meetsAdvancedTextCriteria(FilterType filterType, TextFilter textFilter)
        {
            if (filterType == FilterType.MEDICINE_NAME && (textFilter.Filter == TextmatchFilter.CONTAINS || textFilter.Filter == TextmatchFilter.EQUAL) && hasMedicineName(textFilter)) return true;
            if (filterType == FilterType.MEDICINE_NAME && textFilter.Filter == TextmatchFilter.DOES_NOT_CONTAIN && !hasMedicineName(new TextFilter(textFilter.Text, TextmatchFilter.EQUAL))) return true;
            if ((filterType == FilterType.DOCTORS_NAME || filterType == FilterType.DIAGNOSIS_NAME) && base.meetsAdvancedTextCriteria(filterType, textFilter)) return true;
            return false;
        }

        private bool hasMedicineName(TextFilter filter)
        {
            foreach (MedicalTherapy therapy in MedicalTherapies)
                if (therapy.meetsMedicineNameCriteria(filter)) return true;
            return false;
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