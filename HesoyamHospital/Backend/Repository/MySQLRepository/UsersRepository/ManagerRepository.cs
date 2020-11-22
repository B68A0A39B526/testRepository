// File:    ManagerRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:34
// Purpose: Definition of Class ManagerRepository

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
    public class ManagerRepository : MySQLRepository<Manager, long>, IManagerRepository, IEagerRepository<Manager, long>
    {
        private readonly IUserRepository _userRepository;
        private const string ENTITY_NAME = "Manager";
        private const string NOT_UNIQUE_ERROR = "Manager username {0} is not unique!";
        private string[] INCLUDE_PROPERTIES = { "Address", "UserID","Hospital", "TimeTable" };

        public ManagerRepository(IMySQLStream<Manager> stream, ISequencer<long> sequencer, IUserRepository userRepository) : base(ENTITY_NAME, stream, sequencer, new ManagerIdGeneratorStrategy())
        {
            _userRepository = userRepository;
        }

        public new Manager Create(Manager manager)
        {
            if (IsUsernameUnique(manager.UserName))
            {
                manager.DateCreated = DateTime.Now;
                manager = base.Create(manager);
                _userRepository.AddUser(manager);
                return manager;
            }
            else
                throw new NotUniqueException(string.Format(NOT_UNIQUE_ERROR, manager.UserName));
        }

        public new void Update(Manager manager)
        {
            _userRepository.Update(manager);
            base.Update(manager);
        }

        private bool IsUsernameUnique(string userName)
            => _userRepository.GetByUsername(userName) == null;

        public IEnumerable<Manager> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);

        public Manager GetEager(long id)
            => GetAllEager().SingleOrDefault(manager => manager.GetId() == id);
    }
}