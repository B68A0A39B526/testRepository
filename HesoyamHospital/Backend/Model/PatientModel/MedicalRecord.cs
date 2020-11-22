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
        private long _id;
        private BloodType _patientBloodType;
        private Patient _patient;
        private long _patientID;

        private List<Diagnosis> _patientDiagnosis;
        public List<Allergy> _allergy;

        public long Id { get => _id; set => _id = value; }

        public Patient Patient { get => _patient; set { _patient = value; _patientID = value.Id; } }
        public long PatientID { get => _patientID; set => _patientID = value; }
        public long GetId()
        => _id;

        public void SetId(long id)
            => _id = id;

        public List<Diagnosis> PatientDiagnosis
        {
            get
            {
                if (_patientDiagnosis == null)
                    _patientDiagnosis = new List<Diagnosis>();
                return _patientDiagnosis;
            }
            set
            {
                RemoveAllPatientDiagnosis();
                if (value != null)
                {
                    foreach (Diagnosis oDiagnosis in value)
                        AddPatientDiagnosis(oDiagnosis);
                }
            }
        }

        public List<Allergy> Allergy
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

        public MedicalRecord(long id)
        {
            _id = id;
            
        }

        public MedicalRecord(Patient patient)
        {
            _patient = patient;
            _patientBloodType = BloodType.NOT_TESTED;

            _patientDiagnosis = new List<Diagnosis>();
            _allergy = new List<Allergy>();
        }

        public MedicalRecord(Patient patient, BloodType bloodType)
        {
            _patient = patient;
            _patientBloodType = bloodType;
            _patientDiagnosis = new List<Diagnosis>();
            _allergy = new List<Allergy>();
            _patientID = patient.Id;
        }

        public MedicalRecord(Patient patient,BloodType bloodType,List<Diagnosis> patientDiagnosis, List<Allergy> patientAllergies)
        {
            _patient = patient;
            _patientBloodType = bloodType;
            _patientDiagnosis = patientDiagnosis;
            _allergy = patientAllergies;
            _patientID = patient.Id;
        }

        public MedicalRecord(long id, Patient patient, BloodType bloodType, List<Diagnosis> patientDiagnosis, List<Allergy> patientAllergies)
        {
            _id = id;
            _patient = patient;
            _patientBloodType = bloodType;
            _patientDiagnosis = patientDiagnosis;
            _allergy = patientAllergies;
            _patientID = patient.Id;
        }


        /// <summary>
        /// Property for collection of Diagnosis
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        

        /// <summary>
        /// Add a new Diagnosis in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddPatientDiagnosis(Diagnosis newDiagnosis)
        {
            if (newDiagnosis == null)
                return;
            if (_patientDiagnosis == null)
                _patientDiagnosis = new List<Diagnosis>();
            if (!_patientDiagnosis.Contains(newDiagnosis))
                _patientDiagnosis.Add(newDiagnosis);
        }

        /// <summary>
        /// Remove an existing Diagnosis from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemovePatientDiagnosis(Diagnosis oldDiagnosis)
        {
            if (oldDiagnosis == null)
                return;
            if (_patientDiagnosis != null)
                if (_patientDiagnosis.Contains(oldDiagnosis))
                    _patientDiagnosis.Remove(oldDiagnosis);
        }

        /// <summary>
        /// Remove all instances of Diagnosis from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllPatientDiagnosis()
        {
            if (_patientDiagnosis != null)
                _patientDiagnosis.Clear();
        }
        

        /// <summary>
        /// Property for collection of Allergy
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>

        /// <summary>
        /// Add a new Allergy in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddAllergy(Allergy newAllergy)
        {
            if (newAllergy == null)
                return;
            if (_allergy == null)
                _allergy = new List<Allergy>();
            if (!_allergy.Contains(newAllergy))
                _allergy.Add(newAllergy);
        }

        /// <summary>
        /// Remove an existing Allergy from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveAllergy(Allergy oldAllergy)
        {
            if (oldAllergy == null)
                return;
            if (_allergy != null)
                if (_allergy.Contains(oldAllergy))
                    _allergy.Remove(oldAllergy);
        }

        /// <summary>
        /// Remove all instances of Allergy from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAllergy()
        {
            if (_allergy != null)
                _allergy.Clear();
        }

    

        public override bool Equals(object obj)
        {
            var record = obj as MedicalRecord;
            return record != null &&
                   _id == record._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }


        /// <summary>
        /// Property for BloodType
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public BloodType PatientBloodType
        {
            get { return _patientBloodType; }
            set { _patientBloodType = value; }
        }
        
    }
}