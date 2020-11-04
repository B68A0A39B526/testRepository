// File:    IDiagnosisRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:03:26
// Purpose: Definition of Interface IDiagnosisRepository

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;

namespace Backend.Repository.Abstract.MedicalAbstractRepository
{
    public interface IDiagnosisRepository : IRepository<Diagnosis, long>
    {
        IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient);

        IEnumerable<Diagnosis> GetDiagnosisByMedicine(Medicine medicine);

    }
}