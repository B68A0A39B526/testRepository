// File:    Message.cs
// Author:  Geri
// Created: 18. april 2020 19:55:51
// Purpose: Definition of Class Message

using System;

namespace Backend.Model.UserModel
{
    public class Message : Content
    {
        private bool _opened;
        public bool Opened { get => _opened; set => _opened = value; }

        private User _recipient;
        public User Recipient { get => _recipient; set { _recipient = value; _recipientID = value.Id; } }

        private long _recipientID;
        public long RecipientID { get => _recipientID; set => _recipientID = value; }

        private User _sender;
        public User Sender { get => _sender; set { _sender = value; _senderID = value.Id; } }

        private long _senderID;
        public long SenderID { get => _senderID; set => _senderID = value; }

        public Message(string text, User recipient, User sender) : base(text)
        {
            _opened = false;
            _recipient = recipient;
            _recipientID = recipient.Id;
            _sender = sender;
            _senderID = sender.Id;
        }

        public Message(long id, string text, User recipient, User sender, DateTime dateCreated) : base(id, text, dateCreated)
        {
            _opened = false;
            _recipient = recipient;
            _recipientID = recipient.Id;
            _sender = sender;
            _senderID = sender.Id;
        }

        public Message(long id, string text, User recipient, User sender, DateTime dateCreated, bool opened) : base(id, text, dateCreated)
        {
            _opened = opened;
            _recipient = recipient;
            _recipientID = recipient.Id;
            _sender = sender;
            _senderID = sender.Id;
        }

        public Message(long id) : base(id) { }

    }
}