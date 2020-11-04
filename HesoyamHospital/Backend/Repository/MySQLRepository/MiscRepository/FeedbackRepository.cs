// File:    FeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 18:21:30
// Purpose: Definition of Class FeedbackRepository

using Backend.Model.UserModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Backend.Repository.MySQLRepository.MiscRepository
{
    public class FeedbackRepository : MySQLRepository<Feedback, long>, IFeedbackRepository, IEagerRepository<Feedback, long>
    {
        private const string ENTITY_NAME = "Feedback";
        private string[] INCLUDE_PROPERTIES = { "User" };

        public FeedbackRepository(IMySQLStream<Feedback> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Feedback>())
        {
        }

        public IEnumerable<Feedback> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);

        public Feedback GetEager(long id)
            => GetAllEager().SingleOrDefault(feedback => feedback.GetId() == id);
    }
}