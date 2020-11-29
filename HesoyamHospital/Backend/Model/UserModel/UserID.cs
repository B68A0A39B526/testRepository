// File:    UserID.cs
// Author:  Geri
// Created: 22. maj 2020 13:34:58
// Purpose: Definition of Class UserID

using Backend.Exceptions;
using Backend.Repository.Abstract;
using System;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace Backend.Model.UserModel
{
    public class UserID : IComparable, IIdentifiable<long>
    {
        public long Id { get; set; }
        public char Code { get; set; }
        public int Number { get; set; }

        public static UserID defaultDoctor = new UserID("d0");
        public static UserID defaultPatient = new UserID("p0");
        public static UserID defaultSecretary = new UserID("s0");
        public static UserID defaultManager = new UserID("m0");

        public UserID() { }

        public UserID(string id)
        {
            if(id == null || id.Length < 2)
            {
                throw new InvalidUserIdException();
            }

            Code = id[0];
            try
            {
                Number = Convert.ToInt32(id.Substring(1));
            }
            catch(Exception e)
            {
                throw new InvalidUserIdException("Invalid User ID", e);
            }
        }
        public override string ToString()
        {
            return Code.ToString() + Number;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            UserID otherID = obj as UserID;
            if(Code == otherID.Code)
            {
                return Number.CompareTo(otherID.Number);
            }
            else
            {
                return 1;
            }
        }

        public override bool Equals(object obj)
        {
            UserID otherId = obj as UserID;
            return Code == otherId.Code && Number == otherId.Number;
        }

        public UserID increment()
        {
            Number++;
            return this;
        }

        public UserType GetUserType()
        {
            switch (Code)
            {
                case 'p': return UserType.PATIENT;
                case 'd': return UserType.DOCTOR;
                case 'm': return UserType.MANAGER;
                case 's': return UserType.SECRETARY;
                default: throw new InvalidUserIdException(this.ToString());
            }
        }

        public override int GetHashCode()
        {
            return 999769 * Code.GetHashCode() + Number.GetHashCode();
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}