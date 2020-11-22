// File:    DoctorFeedbackService.cs
// Author:  vule
// Created: 21. maj 2020 15:04:26
// Purpose: Definition of Class DoctorFeedbackService

using System;
using System.Runtime.Serialization;

namespace Backend.Service.MiscService
{
    [Serializable]
    internal class DoctorFeedbackServiceException : Exception
    {
        public DoctorFeedbackServiceException()
        {
        }

        public DoctorFeedbackServiceException(string message) : base(message)
        {
        }

        public DoctorFeedbackServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DoctorFeedbackServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}