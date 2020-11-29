// File:    MedicalRecord.cs
// Author:  Windows 10
// Created: 15. april 2020 21:34:36
// Purpose: Definition of Class MedicalRecord

using System;
using System.Collections.Generic;
using Backend.Repository.Abstract;
using Backend.Model.UserModel;

namespace Backend.Model.PatientModel
{
    public class MedicalRecord : IIdentifiable<long>
    {
        public long Id { get; set; }
        public BloodType PatientBloodType { get; set; }
        public virtual Patient Patient { get; set; }

        private List<Report> _patientReports;
        public virtual List<Report> PatientReports
        {
            get
            {
                if (_patientReports == null)
                    _patientReports = new List<Report>();
                return _patientReports;
            }
            set
            {
                RemoveAllPatientReport();
                if (value != null)
                {
                    foreach (Report oReport in value)
                        AddPatientReport(oReport);
                }
            }
        }
        private List<Allergy> _allergy;
        public virtual List<Allergy> Allergy
        {
            get
            {
                if (_allergy == null)
                    _allergy = new List<Allergy>();
                return _allergy;
            }
            set
            {
                RemoveAllAllergy();
                if (value != null)
                {
                    foreach (Allergy oAllergy in value)
                        AddAllergy(oAllergy);
                }
            }
        }
        private List<Prescription> _prescriptions;
        public virtual List<Prescription> Prescriptions
        {
            get
            {
                if (_prescriptions == null)
                    _prescriptions = new List<Prescription>();
                return _prescriptions;
            }
            set
            {
                RemoveAllPrescription();
                if (value != null)
                {
                    foreach (Prescription oPrescription in value)
                    {
                        if (oPrescription == null)
                            return;
                        if (_prescriptions == null)
                            _prescriptions = new List<Prescription>();
                        if (!_prescriptions.Contains(oPrescription))
                            _prescriptions.Add(oPrescription);
                    }
                }
            }
        }

        public MedicalRecord(long id)
        {
            Id = id;
        }

        public MedicalRecord(Patient patient)
        {
            Patient = patient;
            PatientBloodType = BloodType.NOT_TESTED;
            PatientReports = new List<Report>();
            Allergy = new List<Allergy>();
        }

        public MedicalRecord(Patient patient, BloodType bloodType)
        {
            Patient = patient;
            PatientBloodType = bloodType;
            PatientReports = new List<Report>();
            Allergy = new List<Allergy>();
        }

        public MedicalRecord(Patient patient, BloodType bloodType, List<Report> patientReport, List<Allergy> patientAllergies)
        {
            Patient = patient;
            PatientBloodType = bloodType;
            PatientReports = patientReport;
            Allergy = patientAllergies;
        }

        //constructor for NewPatientMapper
        public MedicalRecord(Patient patient, BloodType bloodType, List<Allergy> patientAllergies)
        {
            Patient = patient;
            PatientBloodType = bloodType;
            Allergy = patientAllergies;
        }

        public MedicalRecord(long id, Patient patient, BloodType bloodType, List<Report> patientReport, List<Allergy> patientAllergies)
        {
            Id = id;
            Patient = patient;
            PatientBloodType = bloodType;
            PatientReports = patientReport;
            Allergy = patientAllergies;
        }

        public long GetId()
        => Id;

        public void SetId(long id)
            => Id = id;


        public void AddPatientReport(Report newReport)
        {
            if (newReport == null)
                return;
            if (PatientReports == null)
                PatientReports = new List<Report>();
            if (!PatientReports.Contains(newReport))
                PatientReports.Add(newReport);
        }

        public void RemovePatientReport(Report oldReport)
        {
            if (oldReport == null)
                return;
            if (PatientReports != null && PatientReports.Contains(oldReport))
                PatientReports.Remove(oldReport);
        }

        public void RemoveAllPatientReport()
        {
            if (PatientReports != null)
                PatientReports.Clear();
        }
        
        public void AddAllergy(Allergy newAllergy)
        {
            if (newAllergy == null)
                return;
            if (Allergy == null)
                Allergy = new List<Allergy>();
            if (!Allergy.Contains(newAllergy))
                Allergy.Add(newAllergy);
        }

        public void RemoveAllergy(Allergy oldAllergy)
        {
            if (oldAllergy == null)
                return;
            if (Allergy != null && Allergy.Contains(oldAllergy))
                Allergy.Remove(oldAllergy);
        }

        public void RemoveAllAllergy()
        {
            if (Allergy != null)
                Allergy.Clear();
        }

        public void AddPrescription(Prescription newPrescription)
        {
            if (newPrescription == null)
                return;
            if (Prescriptions == null)
                Prescriptions = new List<Prescription>();
            if (!Prescriptions.Contains(newPrescription))
                Prescriptions.Add(newPrescription);
        }

        public void RemovePrescription(Prescription oldPrescription)
        {
            if (oldPrescription == null)
                return;
            if (Prescriptions != null && Prescriptions.Contains(oldPrescription))
                Prescriptions.Remove(oldPrescription);
        }

        public void RemoveAllPrescription()
        {
            if (Prescriptions != null)
                Prescriptions.Clear();
        }


        public override bool Equals(object obj)
        {
            var record = obj as MedicalRecord;
            return record != null &&
                   Id == record.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
      
        public string BloodTypeToString(BloodType bt) {
            return bt switch
            {
                BloodType.A_POSITIVE => "A+",
                BloodType.A_NEGATIVE => "A-",
                BloodType.AB_POSITIVE => "AB+",
                BloodType.AB_NEGATIVE => "AB-",
                BloodType.B_POSITIVE => "B+",
                BloodType.B_NEGATIVE => "B-",
                BloodType.O_POSITIVE => "0+",
                BloodType.O_NEGATIVE => "0-",
                BloodType.NOT_TESTED => "Not tested",
                _ => "Not tested",
            };
        }

        public List<string> AllergiesListToString(List<Allergy> allergies) {
            List<string> retVal = new List<string>();
            foreach (Allergy a in allergies) {
                retVal.Add(a.Name);
            }
            if (retVal.Count == 0) {
                retVal.Add("No allergies");
            }

            return retVal;
        }
    }
}