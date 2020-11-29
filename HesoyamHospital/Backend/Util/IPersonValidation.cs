// File:    IPersonValidation.cs
// Author:  Geri
// Created: 22. maj 2020 12:07:12
// Purpose: Definition of Interface IPersonValidation

using System;

namespace Backend.Util
{
    public interface IPersonValidation
    {
        void CheckName(string name);

        void CheckDateOfBirth(DateTime date);

        void CheckPhoneNumber(string phoneNumber);

    }
}