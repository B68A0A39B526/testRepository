// File:    IMedicineRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 13:58:03
// Purpose: Definition of Interface IMedicineRepository

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;

namespace Backend.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IMedicineRepository : IRepository<Medicine, long>
    {
        IEnumerable<Medicine> GetMedicineForDisease(Disease disease);

        IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient);

        Medicine GetMedicineByName(string name);

        IEnumerable<Medicine> GetFilteredMedicine(Util.MedicineFilter medicineFilter);

        IEnumerable<Medicine> GetMedicinePendingApproval();

    }
}