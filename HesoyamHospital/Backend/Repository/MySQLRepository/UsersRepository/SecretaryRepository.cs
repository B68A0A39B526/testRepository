// File:    SecretaryRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:34
// Purpose: Definition of Class SecretaryRepository

using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.UsersRepository
{
    public class SecretaryRepository : MySQLRepository<Secretary, long>, ISecretaryRepository, IEagerRepository<Secretary, long>
    {
        private readonly IUserRepository _userRepository;
        private const string ENTITY_NAME = "Secretary";
        private const string NOT_UNIQUE_ERROR = "Secretary username {0} is not unique!";
        private string[] INCLUDE_PROPERTIES = { "Address", "UserID","Hospital", "TimeTable" };

        public SecretaryRepository(IMySQLStream<Secretary> stream, ISequencer<long> sequencer, IUserRepository userRepository) : base(ENTITY_NAME, stream, sequencer, new SecretaryIdGeneratorStrategy())
        {
            _userRepository = userRepository;
        }

        public new Secretary Create(Secretary secretary)
        {
            if (IsUsernameUnique(secretary.UserName))
            {
                secretary.DateCreated = DateTime.Now;

                secretary = base.Create(secretary);
                _userRepository.AddUser(secretary);
                return secretary;
            }
            else
                throw new NotUniqueException(string.Format(NOT_UNIQUE_ERROR, secretary.UserName));
        }

        public new void Update(Secretary secretary)
        {
            _userRepository.Update(secretary);
            base.Update(secretary);
        }

        private bool IsUsernameUnique(string userName)
            => _userRepository.GetByUsername(userName) == null;

        public IEnumerable<Secretary> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);

        public Secretary GetEager(long id)
            => GetAllEager().SingleOrDefault(secretary => secretary.GetId() == id);

    }
}