// File:    DiagnosisRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class DiagnosisRepository

using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class DiagnosisRepository : MySQLRepository<Diagnosis, long>, IEagerRepository<Diagnosis, long>
    {
        private const string ENTITY_NAME = "Diagnosis";
        
        public DiagnosisRepository(IMySQLStream<Diagnosis> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Diagnosis>())
        {
        }

        public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient)
        {
            var diagnosis = GetAllEager();
            /* treba vratiti dijagnoze za pacijenta, a ne sve*/

            return GetAllEager();
        }
     }
}