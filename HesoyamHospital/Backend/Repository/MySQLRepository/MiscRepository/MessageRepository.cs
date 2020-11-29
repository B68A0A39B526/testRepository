// File:    MessageRepository.cs
// Author:  Geri
// Created: 24. maj 2020 15:56:19
// Purpose: Definition of Class MessageRepository

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
using System.Runtime.InteropServices;

namespace Backend.Repository.MySQLRepository.MiscRepository
{
    public class MessageRepository : MySQLRepository<Message, long>, IMessageRepository, IEagerRepository<Message, long>
    {
        private const string ENTITY_NAME = "Message";

        public MessageRepository(IMySQLStream<Message> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Message>())
        {
        }

        public new Message Create(Message message)
        {
            message.Date = DateTime.Now;
            return base.Create(message);
        }

        public IEnumerable<Message> GetSent(User user)
            => GetAllEager().ToList().Where(message => IsUserIdsEqual(message.Sender, user));

        private bool IsUserIdsEqual(User senderId, User selectedUser)
            => senderId == null ? false : selectedUser.GetId().Equals(senderId.GetId());

        public IEnumerable<Message> GetReceived(User user)
            => GetAllEager().ToList().Where(message => IsUserIdsEqual(message.Recipient, user));
    }
}