// File:    User.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class User

using Backend.Repository.Abstract;
using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;

namespace Backend.Model.UserModel
{
    public class User : Person, IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private string _userName;
        public string UserName { get => _userName; set => _userName = value; }

        private string _password;
        public string Password { get => _password; set => _password = value; }

        private DateTime _dateCreated;
        public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }

        private bool _deleted;
        public bool Deleted { get => _deleted; set => _deleted = value; }

        private UserID _uid;
        public UserID Uid { get => _uid; set => _uid = value; }

        public User() : base() { }

        public User(long id) : base() {
            _id = id;
        }

        public User(string userName,
                    string password, 
                    DateTime dateCreated, 
                    string name, 
                    string surname, 
                    string middleName, 
                    Sex sex, 
                    DateTime dateOfBirth, 
                    string uidn, 
                    Address address, 
                    string homePhone, 
                    string cellPhone, 
                    string email1, 
                    string email2) 
            : base(name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _userName = userName;
            _password = password;
            _dateCreated = dateCreated;
        }

        public User(long id,
                    UserID uid,
                    string userName, 
                    string password, 
                    DateTime dateCreated, 
                    string name, 
                    string surname, 
                    string middleName, 
                    Sex sex, 
                    DateTime dateOfBirth, 
                    string uidn, 
                    Address address, 
                    string homePhone, 
                    string cellPhone, 
                    string email1, 
                    string email2) 
            : base(name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _id = id;
            _uid = uid;
            _userName = userName;
            _password = password;
            _dateCreated = dateCreated;
        }

        public User(string userName,
                    string password,
                    string name,
                    string surname,
                    string middleName,
                    Sex sex,
                    DateTime dateOfBirth,
                    string uidn,
                    Address address,
                    string homePhone,
                    string cellPhone,
                    string email1,
                    string email2)
            : base(name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _userName = userName;
            _password = password;
        }

        public User(long id,
                    UserID uid,
                    string username,
                    string password,
                    DateTime dateCreated,
                    bool deleted)
            : base()
        {
            _id = id;
            _uid = uid;
            _userName = username;
            _password = password;
            _dateCreated = dateCreated;
            _deleted = deleted;
        }

        public UserType GetUserType()
            => _uid.GetUserType();

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            User otherUser = obj as User;
            if (otherUser == null) return false;
            return _id.Equals(otherUser.GetId());
        }

        public override int GetHashCode()
        {
            return 328612020 + EqualityComparer<UserID>.Default.GetHashCode(_uid);
        }
    }
}