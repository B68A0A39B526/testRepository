// File:    IPatientRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:06:33
// Purpose: Definition of Interface IPatientRepository

using System;
using System.Collections.Generic;
using Backend.Model.UserModel;

namespace Backend.Repository.Abstract.UsersAbstractRepository
{
    public interface IPatientRepository : IRepository<Patient, long>
    {
        IEnumerable<Patient> GetPatientByType(PatientType patientType);

        IEnumerable<Patient> GetPatientByDoctor(Doctor doctor);

    }
}