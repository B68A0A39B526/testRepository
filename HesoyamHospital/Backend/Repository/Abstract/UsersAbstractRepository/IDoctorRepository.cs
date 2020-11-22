// File:    IDoctorRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:06:33
// Purpose: Definition of Interface IDoctorRepository

using System;
using System.Collections.Generic;
using Backend.Model.DoctorModel;
using Backend.Model.UserModel;

namespace Backend.Repository.Abstract.UsersAbstractRepository
{
    public interface IDoctorRepository : IRepository<Doctor, long>
    {
        IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType);

        IEnumerable<Doctor> GetFilteredDoctors(Util.DoctorFilter filter);

    }
}