// File:    IHospitalRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 13:57:57
// Purpose: Definition of Interface IHospitalRepository

using System;
using System.Collections.Generic;
using Backend.Model.UserModel;

namespace Backend.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IHospitalRepository : IRepository<Hospital, long>
    {
        IEnumerable<Hospital> GetHospitalByLocation(Location location);

    }
}