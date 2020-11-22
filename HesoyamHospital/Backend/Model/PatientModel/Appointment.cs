// File:    Appointment.cs
// Author:  Windows 10
// Created: 15. april 2020 21:19:22
// Purpose: Definition of Class Appointment

using Backend.Model.UserModel;
using System;
using Backend.Repository.Abstract;
using Backend.Util;
using Backend.Exceptions;

namespace Backend.Model.PatientModel
{
    public class Appointment : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private bool _canceled;
        public bool Canceled { get => _canceled; set => _canceled = value; }

        private AppointmentType _appointmentType;
        public AppointmentType AppointmentType { get => _appointmentType; set => _appointmentType = value; }

        private long _timeIntervalID;
        public long TimeIntervalID { get => _timeIntervalID; set => _timeIntervalID = value; }

        private TimeInterval _timeInterval;
        public TimeInterval TimeInterval { get => _timeInterval; set { _timeInterval = value; _timeIntervalID = value.Id; } }

        private long _patientID;
        public long PatientID { get => _patientID; set => _patientID = value; }

        private Patient _patient;
        public Patient Patient { get => _patient; set { _patient = value; _patientID = value.Id; } }

        private long _doctorInAppointmentID;
        public long DoctorInAppointmentID { get => _doctorInAppointmentID; set => _doctorInAppointmentID = value; }

        private Doctor _doctorInAppointment;
        public Doctor DoctorInAppointment { get => _doctorInAppointment; set { _doctorInAppointment = value; _doctorInAppointmentID = value.Id; } }

        private long _roomID;
        public long RoomID { get => _roomID; set => _roomID = value; }

        public Room _room;
        public Room Room { get => _room; set { _room = value; _roomID = value.Id; } }

      


        public Appointment(long id) => _id = id;

        public Appointment(long id, Doctor doctor, Patient patient, Room room, AppointmentType appointmentType, TimeInterval timeInterval)
        {
            _id = id;
            _doctorInAppointmentID = doctor.Id;
            _doctorInAppointment = doctor;
            _patientID = patient.Id;
            _patient = patient;
            _roomID = room.Id;
            _room = room;
            _appointmentType = appointmentType;
            _timeIntervalID = timeInterval.Id;
            _timeInterval = timeInterval;
            _canceled = false;
        }

        public Appointment(long id, Doctor doctor, Patient patient, Room room, AppointmentType appointmentType, TimeInterval timeInterval, bool canceled)
        {
            _id = id;
            _doctorInAppointmentID = doctor.Id;
            _roomID = room.Id;
            _timeIntervalID = timeInterval.Id;
            _patientID = patient.Id;
            _doctorInAppointment = doctor;
            _patient = patient;
            _room = room;
            _appointmentType = appointmentType;
            _timeInterval = timeInterval;
            _canceled = canceled;
        }

        public Appointment(Doctor doctor,Patient patient,Room room,AppointmentType appointmentType,TimeInterval timeInterval)
        {
            _doctorInAppointmentID = doctor.Id;
            _roomID = room.Id;
            _timeIntervalID = timeInterval.Id;
            _patientID = patient.Id;
            _doctorInAppointment = doctor;
            _patient = patient;
            _room = room;
            _appointmentType = appointmentType;
            _timeInterval = timeInterval;
            _canceled = false;
        }


      
        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public bool IsCompleted()
            => TimeInterval.EndTime <= DateTime.Now;

        public bool IsInFuture()
            => TimeInterval.StartTime >= DateTime.Now;

        public override bool Equals(object obj)
        {
            var appointment = obj as Appointment;
            return appointment != null &&
                   _id == appointment._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}