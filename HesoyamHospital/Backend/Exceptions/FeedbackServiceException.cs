// File:    FeedbackService.cs
// Author:  nikola
// Created: 6. maj 2020 18:46:57
// Purpose: Definition of Class FeedbackService

using System;
using System.Runtime.Serialization;

namespace Backend.Service.MiscService
{
    [Serializable]
    internal class FeedbackServiceException : Exception
    {
        public FeedbackServiceException()
        {
        }

        public FeedbackServiceException(string message) : base(message)
        {
        }

        public FeedbackServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FeedbackServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}