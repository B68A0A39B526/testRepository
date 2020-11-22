// File:    Diagnosis.cs
// Author:  Windows 10
// Created: 16. april 2020 18:22:13
// Purpose: Definition of Class Diagnosis

using System;
using System.Collections.Generic;
using Backend.Repository.Abstract;
using System.Linq;

namespace Backend.Model.PatientModel
{
    public class Diagnosis : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private DateTime _date;
        public DateTime Date { get => _date; set => _date = value; }

        private long _diagnosedDiseaseID;
        public long DiagnosedDiseaseID { get => _diagnosedDiseaseID; set => _diagnosedDiseaseID = value; }


        private Disease _diagnosedDisease;
        public Disease DiagnosedDisease { get => _diagnosedDisease; set { _diagnosedDisease = value; _diagnosedDiseaseID = value.Id; } }

        private List<Therapy> _therapies;

        public List<Therapy> Therapies
        {
            get
            {
                if (_therapies == null)
                    _therapies = new List<Therapy>();
                return _therapies;
            }
            set
            {
                RemoveAllTherapies();
                if (value != null)
                {
                    foreach (Therapy oTherapy in value)
                        AddTherapy(oTherapy);
                }
            }
        }
        private IEnumerable<Therapy> _activeTherapy;
        public IEnumerable<Therapy> ActiveTherapy
        {
            get
            {
                return Therapies.Where(therapy => therapy.TimeInterval.IsDateTimeBetween(DateTime.Now));
            }
        }
        private IEnumerable<Therapy> _inactiveTherapy;
        public IEnumerable<Therapy> InactiveTherapy
        {
            get
            {
                return Therapies.Where(therapy => !therapy.TimeInterval.IsDateTimeBetween(DateTime.Now));
            }
        }

        public Diagnosis(long id)
        {
            _id = id;
        }

        public Diagnosis(Disease disease, List<Therapy> therapies = null)
        {
            //Constructor used when first created by Doctor.
            _diagnosedDisease = disease;
            _diagnosedDiseaseID = disease.Id;
             _date = DateTime.Now;

            if (therapies == null)
                _therapies = new List<Therapy>();
            else
                _therapies = therapies;

        }

        public Diagnosis(long id, Disease disease, List<Therapy> therapies = null)
        {
            _id = id;
            _diagnosedDisease = disease;
            _diagnosedDiseaseID = disease.Id;
            _date = DateTime.Now;
            if (therapies == null)
                therapies = new List<Therapy>();
        }
        public Diagnosis(long id, Disease disease, DateTime issuedOn, List<Therapy> therapies = null)
        {
            //Constructor used for complete initialization(eg. reading from the database)
            _id = id;
            _diagnosedDisease = disease;
            _diagnosedDiseaseID = disease.Id;
            _date = issuedOn;

            if (therapies == null)
                _therapies = new List<Therapy>();
            else
                _therapies = therapies;
        }

        



        //private void ChangeActiveTherapy(Therapy therapy)
        //{
        //    if (_previousTherapies.Contains(therapy))
        //    {
        //        //If we are choosing one from the previous therapies
        //        RemovePreviousTherapies(therapy);
        //    }
        //    else
        //    {
        //       //If it's not one from the previous therapies, we add the current therapy(if not null) to the list of previous therapies
        //       if(_activeTherapy != null)
        //        {
        //            AddPreviousTherapies(_activeTherapy); //We put the active therapy to the list of previous therapies
        //        }
        //    }

        //    _activeTherapy = therapy; //We finally set the active therapy.
        //}

        //public void RemoveActiveTherapy()
        //{
        //    if(_activeTherapy != null)
        //    {
        //        //If there is active therapy at the moment, put it to the list of previous therapies.
        //        _previousTherapies.Add(_activeTherapy);
        //    }
        //    _activeTherapy = null; //Remove active therapy.
        //}



        /// <summary>
        /// Property for collection of Therapy
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        

       
        /// <summary>
        /// Add a new Therapy in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        /// 

        public void AddTherapy(Therapy newTherapy)
        {
            if (newTherapy == null)
                return;
            if (_therapies == null)
                _therapies = new List<Therapy>();
            if (!_therapies.Contains(newTherapy))
                _therapies.Add(newTherapy);
        }

        /// <summary>
        /// Remove an existing Therapy from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveTherapy(Therapy oldTherapy)
        {
            if (oldTherapy == null)
                return;
            if (_therapies != null)
                if (_therapies.Contains(oldTherapy))
                    _therapies.Remove(oldTherapy);
        }

        /// <summary>
        /// Remove all instances of Therapy from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllTherapies()
        {
            if (_therapies != null)
                _therapies.Clear();
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            var diagnosis = obj as Diagnosis;
            return diagnosis != null &&
                   _id == diagnosis._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}