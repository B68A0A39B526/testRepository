// File:    IDoctorFeedbackRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:07:20
// Purpose: Definition of Interface IDoctorFeedbackRepository

using System;
using System.Collections.Generic;
using Backend.Model.DoctorModel;
using Backend.Model.UserModel;

namespace Backend.Repository.Abstract.MiscAbstractRepository
{
    public interface IDoctorFeedbackRepository : IRepository<DoctorFeedback, long>
    {
        IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor);

        DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor);

    }
}