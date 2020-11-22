// File:    PatientService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class PatientService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Model.PatientModel;
using Backend.Exceptions;
using Backend.Util;

namespace Backend.Service.UsersService
{
    public class PatientService : IService<Patient, long>
    {
        PatientRepository _patientRepository;
        MedicalRecordRepository _medicalRecordRepository;
        UserValidation _userValidation;

        public PatientService(PatientRepository patientRepository, MedicalRecordRepository medicalRecordRepository)
        {
            _patientRepository = patientRepository;
            _medicalRecordRepository = medicalRecordRepository;
            _userValidation = new UserValidation();
        }


        public IEnumerable<Patient> GetPatientByType(PatientType patientType)
            => _patientRepository.GetPatientByType(patientType);

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor)
            => _patientRepository.GetPatientByDoctor(doctor);

        public IEnumerable<Patient> GetAll()
            => _patientRepository.GetAllEager();

        public Patient GetByID(long id)
            => _patientRepository.GetByID(id);

        public Patient Create(Patient entity)
        {
            Validate(entity);
            Patient patient = _patientRepository.Create(entity);
            _medicalRecordRepository.Create(new MedicalRecord(patient));

            return patient;

        }

        public void Delete(Patient entity)
            => _patientRepository.Delete(entity);

        public void Validate(Patient user)
            => _userValidation.Validate(user);

        public void Update(Patient entity)
        {
            Validate(entity);
            _patientRepository.Update(entity);
        }

        public UserValidation UserValidation { get => _userValidation; set => _userValidation = value; }
    }
}