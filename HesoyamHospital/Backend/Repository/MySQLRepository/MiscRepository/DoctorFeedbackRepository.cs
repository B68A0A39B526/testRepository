// File:    DoctorFeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:52:51
// Purpose: Definition of Class DoctorFeedbackRepository

using Backend.Model.DoctorModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MiscRepository
{
    public class DoctorFeedbackRepository : MySQLRepository<DoctorFeedback, long>, IDoctorFeedbackRepository, IEagerRepository<DoctorFeedback, long>
    {
        private const string ENTITY_NAME = "DoctorFeedback";
        private string[] INCLUDE_PROPERTIES = { "Doctor" };

        public DoctorFeedbackRepository(IMySQLStream<DoctorFeedback> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<DoctorFeedback>())
        {
        }

        public IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor)
            => GetAllEager().ToList().Where(df => IsUserIdsEqual(df.Doctor, doctor));

        private bool IsUserIdsEqual(User userId, User selectedUser)
            => userId == null ? false : userId.GetId().Equals(selectedUser.GetId());

        public DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor)
            => GetAllEager().ToList().SingleOrDefault(df => IsUserIdsEqual(df.Doctor, doctor) && IsUserIdsEqual(df.User, patient));

        public DoctorFeedback GetEager(long id)
            => GetAllEager().SingleOrDefault(df => df.GetId() == id);

        public IEnumerable<DoctorFeedback> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);
    }
}