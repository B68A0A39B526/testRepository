// File:    MedicalRecordService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class MedicalRecordService

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Exceptions;

namespace Backend.Service.MedicalService
{
    public class MedicalRecordService : IService<MedicalRecord, long>
    {
        private  MedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(MedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public Diagnosis AddDiagnosis(Patient patient, Diagnosis diagnosis)
        {
            MedicalRecord medicalRecord = GetPatientMedicalRecord(patient);
            
            if(medicalRecord == null)
            {
                throw new EntityNotFoundException("Medical record not found!");
            }

            medicalRecord.AddPatientDiagnosis(diagnosis);
            _medicalRecordRepository.Update(medicalRecord);

            return diagnosis;
        }

        public IEnumerable<Allergy> GetPatientAllergies(Patient patient)
        {
            List<Allergy> patientAllergies = new List<Allergy>();
            MedicalRecord patientMedicalRecord = GetPatientMedicalRecord(patient);

            if (patientMedicalRecord == null) return patientAllergies;

            patientAllergies.AddRange(patientMedicalRecord.Allergy);

            return patientAllergies;
        }

        public MedicalRecord GetPatientMedicalRecord(Patient patient)
            => _medicalRecordRepository.GetPatientMedicalRecord(patient);

        public MedicalRecord AddAllergy(MedicalRecord medicalRecord, Allergy allergy)
        {
            medicalRecord.AddAllergy(allergy);
            _medicalRecordRepository.Update(medicalRecord);
            return medicalRecord;
        }

        public IEnumerable<MedicalRecord> GetAll()
            => _medicalRecordRepository.GetAllEager();

        public MedicalRecord GetByID(long id)
            => _medicalRecordRepository.GetEager(id);

        public MedicalRecord Create(MedicalRecord entity){
            Validate(entity);
            return _medicalRecordRepository.Create(entity);
        }


        public void Delete(MedicalRecord entity)
            => _medicalRecordRepository.Delete(entity);

        public void Update(MedicalRecord entity)
        {
            _medicalRecordRepository.Update(entity);
        }

        private void checkIfPatientAlreadyHasMedicalRecord(Patient patient)
        {
            MedicalRecord patientMedicalRecord = GetPatientMedicalRecord(patient);
            if (patientMedicalRecord != null)
            {
                //Patient already has a medical record, therefore we don't want to create a new one.
                throw new MedicalRecordServiceException(String.Format("Patient {0} {1} already has a medical record with ID: {2}", patient.Name, patient.Surname, patientMedicalRecord.GetId()));
            }
        }

        public void Validate(MedicalRecord entity)
        {
            if (entity.Patient == null)
                throw new MedicalRecordServiceException("Medical record must contain an information about patient!");
            checkIfPatientAlreadyHasMedicalRecord(entity.Patient);
        }
    }
}