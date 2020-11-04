// File:    IDiseaseRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:03:39
// Purpose: Definition of Interface IDiseaseRepository

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;

namespace Backend.Repository.Abstract.MedicalAbstractRepository
{
    public interface IDiseaseRepository : IRepository<Disease, long>
    {
        IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms);

        IEnumerable<Disease> GetDiseasesByType(DiseaseType type);

    }
}