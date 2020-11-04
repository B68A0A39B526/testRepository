// File:    SymptomRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:35
// Purpose: Definition of Class SymptomRepository

using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class SymptomRepository : MySQLRepository<Symptom, long>, ISymptomRepository
    {
        private const string ENTITY_NAME = "Symptom";
        public SymptomRepository(IMySQLStream<Symptom> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Symptom>())
        {

        }
    }
}