// File:    DiseaseRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class DiseaseRepository

using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class DiseaseRepository : MySQLRepository<Disease, long>, IDiseaseRepository, IEagerRepository<Disease, long>
    {
        private const string ENTITY_NAME = "Disease";

        public DiseaseRepository(IMySQLStream<Disease> stream, ISequencer<long> sequencer, IEagerRepository<Medicine, long> medicineEagerCSVRepository, ISymptomRepository symptomRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Disease>())
        {
        }

        public IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms)
            => GetAllEager().Where(disease => !disease.Symptoms.Except(symptoms).Any()); //Performs check if disease.Symptoms contains ALL of symptoms.

        public IEnumerable<Disease> GetDiseasesByType(DiseaseType type)
            => GetAllEager().Where(disease => disease.DiseaseType == type);
    }
}