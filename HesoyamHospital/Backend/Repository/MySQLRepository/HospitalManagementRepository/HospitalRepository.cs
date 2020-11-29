// File:    HospitalRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:41
// Purpose: Definition of Class HospitalRepository

using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class HospitalRepository : MySQLRepository<Hospital, long>, IHospitalRepository, IEagerRepository<Hospital, long>
    {
        private const string ENTITY_NAME = "Hospital";
        public HospitalRepository(IMySQLStream<Hospital> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Hospital>()) {}

        public IEnumerable<Hospital> GetHospitalByLocation(Location location)
            => GetAll().ToList().Where(hospital => hospital.Address == null ? false : hospital.Address.Location.Equals(location));
    }
}