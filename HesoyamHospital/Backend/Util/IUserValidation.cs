// File:    IUserValidation.cs
// Author:  Geri
// Created: 22. maj 2020 12:37:45
// Purpose: Definition of Interface IUserValidation

using System;

namespace Backend.Util
{
    public interface IUserValidation : IPersonValidation
    {
        void CheckUsername(string username);

        void CheckPassword(string password);

    }
}