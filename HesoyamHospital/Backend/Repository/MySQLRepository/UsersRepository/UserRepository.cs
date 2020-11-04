// File:    UserRepository.cs
// Author:  vule
// Created: 26. maj 2020 17:35:00
// Purpose: Definition of Class UserRepository

using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Linq;

namespace Backend.Repository.MySQLRepository.UsersRepository
{
    public class UserRepository : MySQLRepository<User, long>, IUserRepository
    {
        private const string ENTITY_NAME = "User";

        public UserRepository(IMySQLStream<User> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new UserIdGeneratorStrategy())
        {
        }

        public new User Create(User user)
        {
            throw new IllegalUserCreationException();
        }

        public User AddUser(User user)
        {
            _stream.Append(user);
            return user;
        }

        public User GetByUsername(string username)
            => _stream.ReadAll().SingleOrDefault(user => user.UserName.Equals(username));

    }
}