// File:    IFeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:54:24
// Purpose: Definition of Interface IFeedbackRepository

using Backend.Model.UserModel;
using System;

namespace Backend.Repository.Abstract.MiscAbstractRepository
{
    public interface IFeedbackRepository : IRepository<Feedback, long>
    {
    }
}