// File:    IngredientRepository.cs
// Author:  nikola
// Created: 24. maj 2020 12:24:56
// Purpose: Definition of Class IngredientRepository

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
    public class IngredientRepository : MySQLRepository<Ingredient, long>, IIngredientRepository
    {
        private const string ENTITY_NAME = "Ingredient";
        public IngredientRepository(IMySQLStream<Ingredient> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Ingredient>())
        {

        }
    }
}