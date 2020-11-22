// File:    AppointmentPatientStrategy.cs
// Author:  nikola
// Created: 21. maj 2020 13:10:55
// Purpose: Definition of Class AppointmentPatientStrategy

using System;
using Backend.Exceptions;
using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;

namespace Backend.Service.MedicalService
{
    public class AppointmentPatientStrategy : IAppointmentStrategy
    {
        private readonly int bottomHourMargin = 24; //Represent hours after which you can't make an appointment
        private readonly int topDayMargin = 90; //Represents maximum upfront days when patient can make an appointment

        public void checkDateTimeValid(Appointment appointment)
        {
            DateTime startTime = appointment.TimeInterval.StartTime;
            DateTime endTime = appointment.TimeInterval.EndTime;

            if (startTime < DateTime.Now.AddHours(bottomHourMargin))
                throw new AppointmentServiceException("Appointment start time is too soon!");

            if (startTime > endTime)
                throw new AppointmentServiceException("Appointment start time must be before end time!");

            if (startTime > DateTime.Now.AddDays(topDayMargin))
                throw new AppointmentServiceException("Appointment can't be made too far in the future!");
        }

        public void CheckType(Appointment appointment)
        {
            AppointmentType appointmentType = appointment.AppointmentType;
            Doctor doctor = appointment.DoctorInAppointment;
            Patient patient = appointment.Patient;

            if (appointmentType == AppointmentType.operation && (doctor.DoctorType == DoctorType.FAMILYMEDICINE))
                throw new AppointmentServiceException("Family medicine doctor can not book operation!");
            else if (appointmentType == AppointmentType.renovation && (doctor != null || patient != null))
                throw new AppointmentServiceException("Doctor and patient can not be in renovation appointment!");
        }

        public bool isAppointmentChangeable(Appointment appointment)
        {
            DateTime startTime = appointment.TimeInterval.StartTime;
            return startTime.AddHours(-bottomHourMargin) > DateTime.Now && startTime.AddDays(-topDayMargin) < DateTime.Now;
        }

        public void Validate(Appointment appointment)
        {
            checkDateTimeValid(appointment);
            CheckType(appointment);
        }
    }
}