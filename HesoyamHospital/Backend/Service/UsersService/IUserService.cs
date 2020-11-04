// File:    IUserService.cs
// Author:  Geri
// Created: 22. maj 2020 11:50:44
// Purpose: Definition of Interface IUserService

using Backend.Model.UserModel;
using System;

namespace Backend.Service.UsersService
{
    public interface IUserService<T>
    {
        //void Validate(T user);

        void Login(string username, string password);

    }
}