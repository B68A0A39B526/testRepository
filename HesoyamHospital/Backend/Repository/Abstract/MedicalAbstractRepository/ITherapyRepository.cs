// File:    ITherapyRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:05:08
// Purpose: Definition of Interface ITherapyRepository

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;

namespace Backend.Repository.Abstract.MedicalAbstractRepository
{
    public interface ITherapyRepository : IRepository<Therapy, long>
    {

        IEnumerable<Therapy> GetTherapyByDate(Util.TimeInterval dateRange);

        IEnumerable<Therapy> GetTherapyByMedicine(Medicine medicine);

        IEnumerable<Therapy> GetTherapyByPatient(Patient patient);

        IEnumerable<Therapy> GetFilteredTherapy(Util.TherapyFilter filter);

        IEnumerable<Therapy> GetTherapyByDiagnosis(Diagnosis diagnosis);

        IEnumerable<Therapy> GetActiveTherapyForPatient(Patient patient);

        IEnumerable<Therapy> GetPastTherapyForPatient(Patient patient);

        IEnumerable<Therapy> GetActiveTherapyForDiagnosis(Diagnosis diagnosis);

        IEnumerable<Therapy> GetPastTherapiesForDiagnosis(Diagnosis diagnosis);

    }
}