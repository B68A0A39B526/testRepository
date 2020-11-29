// File:    NotificationRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:31:13
// Purpose: Definition of Class NotificationRepository

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

namespace Backend.Repository.MySQLRepository.MiscRepository
{
    public class NotificationRepository : MySQLRepository<Notification, long>, INotificationRepository, IEagerRepository<Notification, long>
    {
        private const string ENTITY_NAME = "Notification";

        public NotificationRepository(IMySQLStream<Notification> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Notification>())
        {
        }

        public new Notification Create(Notification notification)
        {
            notification.Date = DateTime.Now;
            return base.Create(notification);
        }

        public IEnumerable<Notification> GetNotificationByUser(User user)
            => GetAll().ToList().Where(notification => notification.Recipient == null ? false : notification.Recipient.GetId().Equals(user.GetId()));
    
    }
}