// File:    IAppointmentRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:02:02
// Purpose: Definition of Interface IAppointmentRepository

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Util;

namespace Backend.Repository.Abstract.MedicalAbstractRepository
{
    public interface IAppointmentRepository : IRepository<Appointment, long>
    {
        IEnumerable<Appointment> GetPatientAppointments(Patient patient);

        IEnumerable<Appointment> GetAppointmentsByTime(Util.TimeInterval timeInterval);

        IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor);

        IEnumerable<Appointment> GetCanceledAppointments();

        IEnumerable<Appointment> GetAppointmentsByRoom(Room room);

        IEnumerable<Appointment> GetFilteredAppointment(AppointmentFilter appointmentFilter);

    }
}