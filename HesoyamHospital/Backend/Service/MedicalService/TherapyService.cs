// File:    TherapyService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class TherapyService

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Util;

using System.Linq;

using Backend.Exceptions;
namespace Backend.Service.MedicalService
{
    public class TherapyService : IService<Therapy, long>
    {
        private TherapyRepository _therapyRepository;
        private MedicalRecordService _medicalRecordService;
        public TherapyService(TherapyRepository therapyRepository,MedicalRecordService medicalRecordService)
        {
            _therapyRepository = therapyRepository;
            _medicalRecordService = medicalRecordService;
        }
       
        public Prescription SetPerscription(Therapy therapy, Prescription prescription)
        {
            therapy.Prescription = prescription;
            _therapyRepository.Update(therapy);
            return prescription;
        }

        public IEnumerable<Therapy> GetTherapyByDate(TimeInterval dateRange)
            => _therapyRepository.GetTherapyByDate(dateRange);

        public IEnumerable<Therapy> GetTherapyByMedicine(Medicine medicine)
            => _therapyRepository.GetTherapyByMedicine(medicine);

        public IEnumerable<Therapy> GetTherapyByPatient(Patient patient)
            => _therapyRepository.GetTherapyByPatient(patient);

        public IEnumerable<Therapy> GetFilteredTherapy(TherapyFilter filter)
            => _therapyRepository.GetFilteredTherapy(filter);

        public IEnumerable<Therapy> GetActiveTherapyForPatient(Patient patient)
            => _therapyRepository.GetActiveTherapyForPatient(patient);

        public IEnumerable<Therapy> GetPastTherapyForPatient(Patient patient)
            => _therapyRepository.GetPastTherapyForPatient(patient);


        public void ConsumeTherapy(Therapy therapy)
        {
            //TODO: Do we even need this?
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetAll()
            => _therapyRepository.GetAllEager();

        public Therapy GetByID(long id)
            => _therapyRepository.GetEager(id);

        public Therapy Create(Therapy entity)
        {
            Validate(entity);
            return _therapyRepository.Create(entity);
        }

        public void Delete(Therapy entity)
            => _therapyRepository.Delete(entity);

        public void Update(Therapy entity)
        {
            Validate(entity);
            _therapyRepository.Update(entity);
        }

        public void Validate(Therapy entity)
        {
            if (entity.TimeInterval.StartTime > entity.TimeInterval.EndTime)
                throw new TherapyServiceException("Start time must be before end time!");
            if (entity.TimeInterval.StartTime < DateTime.Now)
                throw new TherapyServiceException("Therapy start time must be in the future!");  
        }
    }
}