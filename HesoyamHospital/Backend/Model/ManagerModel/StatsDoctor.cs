// File:    StatsDoctor.cs
// Author:  vule
// Created: 18. april 2020 17:12:34
// Purpose: Definition of Class StatsDoctor

using Backend.Model.UserModel;
using System;

namespace Backend.Model.ManagerModel
{
    public class StatsDoctor : Stats
    {
        private double _numberOfAppointments;
        private string _avgAppointmentTime;
        private Doctor _doctor;
        private long _doctorID;

        public long DoctorId { get => _doctorID; set => _doctorID = value; }

        public double NumberOfAppointments {get {return _numberOfAppointments ;} set { _numberOfAppointments = value; }}

        public string AvgAppointmentTime { get { return _avgAppointmentTime; } set { _avgAppointmentTime = value; } }

        public Doctor Doctor { get { return _doctor; } set { _doctor = value; _doctorID = value.Id; } }

        public StatsDoctor(double numberOfAppointments, string avgAppointmentTime, Doctor doctor): base()
        {
            _numberOfAppointments = numberOfAppointments;
            _avgAppointmentTime = avgAppointmentTime;
            _doctor = doctor;
            _doctorID = doctor.Id;
        }

        public StatsDoctor(long id, double numberOfAppointments, string avgAppointmentTime, Doctor doctor) : base(id)
        {
            _numberOfAppointments = numberOfAppointments;
            _avgAppointmentTime = avgAppointmentTime;
            _doctor = doctor;
            _doctorID = doctor.Id;
        }

        public StatsDoctor(long id): base(id)
        {
        }
    }
}