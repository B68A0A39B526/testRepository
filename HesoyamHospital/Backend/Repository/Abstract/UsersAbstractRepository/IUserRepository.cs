// File:    IUserRepository.cs
// Author:  vule
// Created: 26. maj 2020 17:27:21
// Purpose: Definition of Interface IUserRepository

using Backend.Model.UserModel;
using System;

namespace Backend.Repository.Abstract.UsersAbstractRepository
{
    public interface IUserRepository : IRepository<User, long>
    {
        User GetByUsername(string username);

        User AddUser(User user);

    }
}