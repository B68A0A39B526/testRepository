// File:    AppointmentSecretaryStrategy.cs
// Author:  nikola
// Created: 21. maj 2020 13:11:36
// Purpose: Definition of Class AppointmentSecretaryStrategy

using System;
using Backend.Exceptions;
using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;

namespace Backend.Service.MedicalService
{
    public class AppointmentSecretaryStrategy : IAppointmentStrategy
    {
        private readonly int bottomMinuteMargin = 10;
        public void checkDateTimeValid(Appointment appointment)
        {
            DateTime startTime = appointment.TimeInterval.StartTime;
            DateTime endTime = appointment.TimeInterval.EndTime;

            if (startTime < DateTime.Now.AddMinutes(bottomMinuteMargin))
                throw new AppointmentServiceException("Appointment start time is too soon!");

            if (startTime > endTime)
                throw new AppointmentServiceException("Appointment start time must be before end time!");
        }

        public void CheckType(Appointment appointment)
        {
            AppointmentType appointmentType = appointment.AppointmentType;
            Doctor doctor = appointment.DoctorInAppointment;
            Patient patient = appointment.Patient;
            Room room = appointment.Room;

            if (appointmentType == AppointmentType.operation && (doctor.DoctorType == DoctorType.FAMILYMEDICINE))
                throw new AppointmentServiceException("Family medicine doctor can not book operation!");
            if(appointmentType == AppointmentType.renovation)
                throw new AppointmentServiceException("Secretary cannot book renovation!");
            if (doctor == null || patient == null || room == null)
                throw new AppointmentServiceException("Doctor, patient and room must be set.");
        }

        public bool isAppointmentChangeable(Appointment appointment)
            => appointment.TimeInterval.StartTime.AddMinutes(-bottomMinuteMargin) > DateTime.Now;


        public void Validate(Appointment appointment)
        {
            checkDateTimeValid(appointment);
            CheckType(appointment);
        }
    }
}