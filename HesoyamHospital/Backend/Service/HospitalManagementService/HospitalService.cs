// File:    HospitalService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class HospitalService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Backend.Exceptions;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Util;

namespace Backend.Service.HospitalManagementService
{
    public class HospitalService : IService<Hospital, long>
    {
        HospitalRepository _hospitalRepository; 

        public HospitalService(HospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public IEnumerable<Hospital> GetHospitalByLocation(Location location)
            => _hospitalRepository.GetHospitalByLocation(location);

        public IEnumerable<Hospital> GetAll()
            => _hospitalRepository.GetAllEager();

        public Hospital GetByID(long id)
            => _hospitalRepository.GetByID(id);

        public Hospital Create(Hospital entity)
        {
            Validate(entity);
            return _hospitalRepository.Create(entity);
        }

        public void Update(Hospital entity)
        {
            Validate(entity);
            _hospitalRepository.Update(entity);
        }

        public void Delete(Hospital entity)
            => _hospitalRepository.Delete(entity);

        public void Validate(Hospital entity)
        {
            CheckName(entity);
            CheckPhone(entity);
        }

        private void CheckPhone(Hospital hospital)
        {
            if (!Regex.Match(hospital.Telephone, Regexes.phoneRegex).Success)
            {
                throw new HospitalServiceException("Hospital Service - Telephone is not valid!");
            }
        }

        private void CheckName(Hospital hospital)
        { 
            if(Regex.IsMatch(Regexes.nameRegex, hospital.Name))
            {
                throw new HospitalServiceException("Hospital Service - Name is not valid!");
            }
        }

        public IHospitalRepository iHospitalRepository;

    }
}