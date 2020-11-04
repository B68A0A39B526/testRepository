// File:    AppointmentFilter.cs
// Author:  nikola
// Created: 21. maj 2020 12:39:03
// Purpose: Definition of Class AppointmentFilter

using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using System;

namespace Backend.Util
{
    public class AppointmentFilter
    {
        private DoctorType _doctorType;
        private Doctor _doctor;
        private TimeInterval _timeInterval;
        private AppointmentType _type;

        public AppointmentFilter(Doctor doctor, DoctorType doctorType, TimeInterval timeInterval, AppointmentType appointmentType)
        {
            _doctor = doctor;
            _doctorType = doctorType;
            _timeInterval = timeInterval;
            _type = appointmentType;
        }

        public DoctorType DoctorType { get => _doctorType; set => _doctorType = value; }
        public Doctor Doctor { get => _doctor; set => _doctor = value; }
        public TimeInterval TimeInterval { get => _timeInterval; set => _timeInterval = value; }
        public AppointmentType Type { get => _type; set => _type = value; }
    }
}