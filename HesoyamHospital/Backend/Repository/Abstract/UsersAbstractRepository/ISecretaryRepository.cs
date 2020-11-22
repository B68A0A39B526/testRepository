// File:    ISecretaryRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:08:58
// Purpose: Definition of Interface ISecretaryRepository

using Backend.Model.UserModel;
using System;

namespace Backend.Repository.Abstract.UsersAbstractRepository
{
    public interface ISecretaryRepository : IRepository<Secretary, long>
    {
    }
}