// File:    MedicalRecordRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:35
// Purpose: Definition of Class MedicalRecordRepository

using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class MedicalRecordRepository : MySQLRepository<MedicalRecord, long>, IMedicalRecordRepository, IEagerRepository<MedicalRecord, long>
    {
        private const string ENTITY_NAME = "MedicalRecord";
        private string[] INCLUDE_PROPERTIES = { "PatientDiagnosis", "Allergy", "Patient" };

        public MedicalRecordRepository(IMySQLStream<MedicalRecord> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<MedicalRecord>())
        {
        }

        public MedicalRecord GetPatientMedicalRecord(Patient patient)
            => GetAllEager().SingleOrDefault(medicalRecord => medicalRecord.Patient.Equals(patient));

        public MedicalRecord GetEager(long id)
            => GetAllEager().SingleOrDefault(medicalRecord => medicalRecord.GetId() == id);

        public IEnumerable<MedicalRecord> GetAllEager()
             => GetAllEager(INCLUDE_PROPERTIES);
    }
}