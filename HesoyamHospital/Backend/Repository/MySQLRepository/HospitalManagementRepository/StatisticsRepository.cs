// File:    StatisticsRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:39
// Purpose: Definition of Class StatisticsRepository

using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class StatisticsRepository : MySQLRepository<Stats, long>, IStatisticsRepository, IEagerRepository<Stats, long>
    {
        public StatisticsRepository(string entityName, IMySQLStream<Stats> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Stats>())
        {
        }

        public IEnumerable<StatsDoctor> GetDoctorStatistics()
            => (IEnumerable<StatsDoctor>) GetAll().Where(stat => stat.GetType().Equals(new StatsDoctor(100).GetType()));

        public Doctor GetStatisticsByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetStatisticsByItem(Item item)
        {
            throw new NotImplementedException();
        }

        public StatsRoom GetStatisticsByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatsRoom> GetRoomStatistics()
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetInventoryStatistics()
        {
            throw new NotImplementedException();
        }

        public Stats GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stats> GetAllEager()
        {
            throw new NotImplementedException();
        }

    }
}