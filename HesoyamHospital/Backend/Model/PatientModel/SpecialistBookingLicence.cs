// File:    SpecialistBookingLicence.cs
// Author:  Windows 10
// Created: 15. april 2020 21:47:38
// Purpose: Definition of Class SpecialistBookingLicence

using Backend.Model.DoctorModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Backend.Model.PatientModel
{
    public class SpecialistBookingLicence : IIdentifiable<long>
    {
        private long _id;
        private DoctorType _doctorAllowed;
        private int _numberOfAppointments;
        private bool _active;
        private Patient _patient;
        private long _patientId;
        private TimeInterval _timeInterval;
        private long _timeIntervalID;
        private List<Doctor> _handsOutLicence;


        public Patient Patient { get => _patient; set { _patient = value; _patientId = value.Id; } }
        public long PatientId { get => _patientId; set => _patientId = value; }
        public TimeInterval TimeInterval { get => _timeInterval; set { _timeInterval = value; _timeIntervalID = value.Id; } }
        public long TimeIntervalID { get => _timeIntervalID; set => _timeIntervalID = value; }
        public long Id { get => _id; set => _id = value; }

        public List<Doctor> HandsOutLicence { get => _handsOutLicence; }
        
        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }

        //TODO: Constructors

        public SpecialistBookingLicence(long id, DoctorType doctorAllowed, int numberOfAppointments, bool Active, Patient patient, TimeInterval timeInterval, List<Doctor> handsOutLicence) 
        {
            _id = id;
            _doctorAllowed = doctorAllowed;
            _numberOfAppointments = numberOfAppointments;
            _active = Active;
            _patient = patient;
            _timeInterval = timeInterval;
            _handsOutLicence = handsOutLicence;
        }

        public SpecialistBookingLicence (DoctorType doctorAllowed, int numberOfAppointments, bool Active, Patient patient, TimeInterval timeInterval, List<Doctor> handsOutLicence)
        {
            _doctorAllowed = doctorAllowed;
            _numberOfAppointments = numberOfAppointments;
            _active = Active;
            _patient = patient;
            _timeInterval = timeInterval;
            _handsOutLicence = handsOutLicence;
        }


        

        public override bool Equals(object obj)
        {
            var licence = obj as SpecialistBookingLicence;
            return licence != null &&
                   _id == licence._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}