// File:    MedicineService.cs
// Author:  Geri
// Created: 20. maj 2020 10:27:14
// Purpose: Definition of Class MedicineService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Backend.Exceptions;
using Backend.Model.PatientModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Util;

namespace Backend.Service.HospitalManagementService
{
    public class MedicineService : IService<Medicine, long>
    {

        private MedicineRepository _medicineRepository;

        public MedicineService(MedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease)
            => _medicineRepository.GetMedicineForDisease(disease);

        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient)
            => _medicineRepository.GetMedicineByIngredient(ingredient);

        public Medicine GetMedicineByName(string name)
            => _medicineRepository.GetMedicineByName(name);

        public IEnumerable<Medicine> GetFilteredMedicine(Util.MedicineFilter medicineFilter)
            => _medicineRepository.GetFilteredMedicine(medicineFilter);

        public IEnumerable<Medicine> GetMedicinePendingApproval()
            => _medicineRepository.GetMedicinePendingApproval();

        public IEnumerable<Medicine> GetAll()
            => _medicineRepository.GetAllEager();

        public Medicine GetByID(long id)
            => _medicineRepository.GetByID(id);

        public Medicine Create(Medicine entity)
        {
            Validate(entity);
            return _medicineRepository.Create(entity);
        }

        public void Update(Medicine entity)
        {
            Validate(entity);
            _medicineRepository.Update(entity);
        }

        public void Delete(Medicine entity)
            => _medicineRepository.Delete(entity);

        public void Validate(Medicine entity)
        {
            CheckStrength(entity.Strength);
            CheckInStock(entity.InStock);
            CheckMinNumber(entity.MinNumber);
            CheckName(entity.Name);
        }

        private void CheckName(string name)
        {
            if (!Regex.Match(name, Regexes.medicineNamePattern).Success)
                throw new MedicineServiceException("Name contains illegal characters!");
        }

        private void CheckMinNumber(int minNumber)
        {
            if (minNumber < 0)
                throw new MedicineServiceException("MinNumber is less than zero!");
        }

        private void CheckInStock(int inStock)
        {
            if (inStock < 0)
                throw new MedicineServiceException("InStock is less than zero!");
        }

        private void CheckStrength(double strength)
        {
            if (strength < 0)
                throw new MedicineServiceException("Strength is less than zero!");
        }

    }
}