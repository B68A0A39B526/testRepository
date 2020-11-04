// File:    IAllergyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 12:42:12
// Purpose: Definition of Interface IAllergyRepository

using Backend.Model.PatientModel;
using System;

namespace Backend.Repository.Abstract.MedicalAbstractRepository
{
    public interface IAllergyRepository : IRepository<Allergy, long>
    {
    }
}