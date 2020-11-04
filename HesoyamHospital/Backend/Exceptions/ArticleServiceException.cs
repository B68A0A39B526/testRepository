// File:    ArticleService.cs
// Author:  Geri
// Created: 7. maj 2020 12:01:08
// Purpose: Definition of Class ArticleService

using System;
using System.Runtime.Serialization;

namespace Backend.Service.MiscService
{
    [Serializable]
    internal class ArticleServiceException : Exception
    {
        public ArticleServiceException()
        {
        }

        public ArticleServiceException(string message) : base(message)
        {
        }

        public ArticleServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArticleServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}