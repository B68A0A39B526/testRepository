// File:    LocationService.cs
// Author:  Geri
// Created: 7. maj 2020 12:08:07
// Purpose: Definition of Class LocationService

using System;
using System.Runtime.Serialization;

namespace Backend.Service.MiscService
{
    [Serializable]
    internal class LocationServiceException : Exception
    {
        public LocationServiceException()
        {
        }

        public LocationServiceException(string message) : base(message)
        {
        }

        public LocationServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LocationServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}