/***********************************************************************
 * Module:  Disease.cs
 * Author:  nikola
 * Purpose: Definition of the Class Disease
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Backend.Repository.Abstract;

namespace Backend.Model.PatientModel
{
    public class Disease : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public bool IsChronic { get; set; }
        public virtual DiseaseType DiseaseType { get; set; }

        private List<DiseaseMedicine> _administratedFor;
        public virtual List<DiseaseMedicine> AdministratedFor
        {
            get
            {
                if (_administratedFor == null)
                    _administratedFor = new List<DiseaseMedicine>();
                return _administratedFor;
            }
            set
            {
                RemoveAllAdministratedFor();
                if (value != null)
                {
                    foreach (DiseaseMedicine oMedicine in value)
                        AddAdministratedFor(oMedicine.Medicine);
                }
            }
        }
        private List<Symptom> _symptoms;
        public virtual List<Symptom> Symptoms
        {
            get
            {
                if (_symptoms == null)
                    _symptoms = new List<Symptom>();
                return _symptoms;
            }
            set
            {
                RemoveAllSymptoms();
                if (value != null)
                {
                    foreach (Symptom oSymptom in value)
                        AddSymptoms(oSymptom);
                }
            }
        }

        public Disease(long id)
        {
            Id = id;
        }

        public Disease(long id, string name, string overview, bool isChronic, DiseaseType diseaseType, List<Symptom> symptoms, List<DiseaseMedicine> administratedFor = null)
        {
            Id = id;
            Name = name;
            Overview = overview;
            IsChronic = isChronic;
            DiseaseType = diseaseType;
            Symptoms = symptoms;

            if (administratedFor == null)
                AdministratedFor = new List<DiseaseMedicine>();
            else
                AdministratedFor = administratedFor;
        }

        public Disease(string name, string overview, bool isChronic, DiseaseType diseaseType,List<Symptom> symptoms,List<DiseaseMedicine> administratedFor = null)
        {
            Name = name;
            Overview = overview;
            IsChronic = isChronic;
            DiseaseType = diseaseType;
            Symptoms = symptoms;

            if (administratedFor == null)
                AdministratedFor = new List<DiseaseMedicine>();
            else
                AdministratedFor = administratedFor;
        }

        public void AddAdministratedFor(Medicine newMedicine)
        {
            if (newMedicine == null)
                return;
            if (AdministratedFor == null)
                AdministratedFor = new List<DiseaseMedicine>();
            if(AdministratedFor.Find(dm => dm.Medicine.Equals(newMedicine)) == null)
            {
                DiseaseMedicine dm = new DiseaseMedicine(this, newMedicine);
                AdministratedFor.Add(dm);
                newMedicine.AddUsedFor(this);
            }
        }

        /// <summary>
        /// Remove an existing Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveAdministratedFor(Medicine oldMedicine)
        {
            if (oldMedicine == null)
                return;
            if (AdministratedFor != null && AdministratedFor.Find(dm => dm.Medicine.Equals(oldMedicine)) == null)
            {
                DiseaseMedicine removeDm = AdministratedFor.Find(dm => dm.Medicine.Equals(oldMedicine));
                if(removeDm != null)
                {
                    AdministratedFor.Remove(removeDm);
                    oldMedicine.RemoveUsedFor(this);
                }
            }
        }

        /// <summary>
        /// Remove all instances of Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAdministratedFor()
        {
            if (AdministratedFor != null)
            {
                List<Medicine> tmpAdministratedFor = new List<Medicine>();
                foreach (DiseaseMedicine oldMedicine in AdministratedFor)
                    tmpAdministratedFor.Add(oldMedicine.Medicine);
                AdministratedFor.Clear();
                foreach (Medicine oldMedicine in tmpAdministratedFor)
                    oldMedicine.RemoveUsedFor(this);
                tmpAdministratedFor.Clear();
            }
        }

        public void AddSymptoms(Symptom newSymptom)
        {
            if (newSymptom == null)
                return;
            if (Symptoms == null)
                Symptoms = new List<Symptom>();
            if (!Symptoms.Contains(newSymptom))
                Symptoms.Add(newSymptom);
        }

        /// <summary>
        /// Remove an existing Symptom from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveSymptoms(Symptom oldSymptom)
        {
            if (oldSymptom == null)
                return;
            if (Symptoms != null && Symptoms.Contains(oldSymptom))
                Symptoms.Remove(oldSymptom);
        }

        /// <summary>
        /// Remove all instances of Symptom from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllSymptoms()
        {
            if (Symptoms != null)
                Symptoms.Clear();
        }

        public long GetId()
            => Id;

        public void SetId(long id)
            => Id = id;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Disease otherDisease = obj as Disease;
            return Id == otherDisease.GetId();
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}