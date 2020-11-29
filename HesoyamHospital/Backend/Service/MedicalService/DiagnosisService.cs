// File:    DiagnosisService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class DiagnosisService

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MedicalRepository;

namespace Backend.Service.MedicalService
{
    public class DiagnosisService : IService<Diagnosis, long>
    {
        private DiagnosisRepository _diagnosisRepository;

        public DiagnosisService(DiagnosisRepository diagnosisRepository)
        {
            _diagnosisRepository = diagnosisRepository;
        }

        public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient)
            => _diagnosisRepository.GetAllDiagnosisForPatient(patient);

        public IEnumerable<Diagnosis> GetAll()
            => _diagnosisRepository.GetAllEager();

        public Diagnosis GetByID(long id)
            => _diagnosisRepository.GetEager(id);

        public Diagnosis Create(Diagnosis entity)
            => _diagnosisRepository.Create(entity);

        public void Update(Diagnosis entity)
            => _diagnosisRepository.Update(entity);

        public void Delete(Diagnosis entity)
            => _diagnosisRepository.Delete(entity);

        public void Validate(Diagnosis entity)
        {
            //Nothing to validate.
        }
    }
}