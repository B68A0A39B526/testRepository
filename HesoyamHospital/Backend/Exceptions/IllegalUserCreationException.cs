// File:    UserRepository.cs
// Author:  vule
// Created: 26. maj 2020 17:35:00
// Purpose: Definition of Class UserRepository

using System;
using System.Runtime.Serialization;

namespace Backend.Repository.MySQLRepository.UsersRepository
{
    [Serializable]
    internal class IllegalUserCreationException : Exception
    {
        public IllegalUserCreationException()
        {
        }

        public IllegalUserCreationException(string message) : base(message)
        {
        }

        public IllegalUserCreationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalUserCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}