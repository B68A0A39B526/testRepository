// File:    MessageService.cs
// Author:  Geri
// Created: 7. maj 2020 12:02:29
// Purpose: Definition of Class MessageService

using System;
using System.Collections.Generic;
using Backend.Exceptions;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.MySQLRepository.MiscRepository;

namespace Backend.Service.MiscService
{
    public class MessageService : IService<Message, long>
    {
        private MessageRepository _messageRepository;

        public MessageService(MessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetSent(User user)
            => _messageRepository.GetSent(user);

        public IEnumerable<Message> GetRecieved(User user)
            => _messageRepository.GetReceived(user);

        public IEnumerable<Message> GetAll()
            => _messageRepository.GetAllEager();

        public Message GetByID(long id)
            => _messageRepository.GetByID(id);

        public Message Create(Message entity)
        {
            Validate(entity);
            return _messageRepository.Create(entity);
        }

        public void Update(Message entity)
        {
            Validate(entity);
            _messageRepository.Create(entity);
        }

        public void Delete(Message entity)
            => _messageRepository.Delete(entity);

        public void Validate(Message entity)
        {
            if (entity.Sender == null)
            {
                throw new MessageServiceException("MessageService - Sender is not set!");
            }

            if (entity.Recipient == null)
            {
                throw new MessageServiceException("MessageService - Recipient is not set!");
            }
        }
    }
}