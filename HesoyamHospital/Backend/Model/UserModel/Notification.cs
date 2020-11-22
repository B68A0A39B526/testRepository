// File:    Notification.cs
// Author:  Geri
// Created: 18. april 2020 20:15:06
// Purpose: Definition of Class Notification

using System;

namespace Backend.Model.UserModel
{
    public class Notification : Content
    {
        private User _recipient;
        public User Recipient { get => _recipient; set { _recipient = value; _recipientID = value.Id; } }

        private long _recipientID;
        public long RecipientID { get => _recipientID; set => _recipientID = value; }

        public Notification(string text, User recipient, DateTime dateCreated) : base(text, dateCreated)
        {
            _recipient = recipient;
            _recipientID = recipient.Id;
        }

        public Notification(string text, User recipient) : base(text)
        {
            _recipient = recipient;
            _recipientID = recipient.Id;
        }

        public Notification(long id, string text, User recipient, DateTime dateCreated) : base(id, text, dateCreated)
        {
            _recipient = recipient;
            _recipientID = recipient.Id;
        }

        public Notification(long id) : base(id) { }

    }
}