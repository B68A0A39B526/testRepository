// File:    AllergyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 13:02:09
// Purpose: Definition of Class AllergyRepository

using Backend.Model.PatientModel;
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
    public class AllergyRepository : MySQLRepository<Allergy, long>, IAllergyRepository, IEagerRepository<Allergy,long>
    {
        private const string ENTITY_NAME = "Allergy";
        private string[] INCLUDE_PROPERTIES = { "AllergicToIngredient", "Symptoms" };

        public AllergyRepository(IMySQLStream<Allergy> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Allergy>())
        {
        }

        public IEnumerable<Allergy> GetAllEager()
             => GetAllEager(INCLUDE_PROPERTIES);

        public Allergy GetEager(long id)
            => GetAllEager().SingleOrDefault(allergy => allergy.GetId() == id);
    }
}