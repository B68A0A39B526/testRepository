using System;
using System.Collections.Generic;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;

//CSVRepository<Stats, long>, IStatisticsRepository, IEagerRepository<Stats, long>

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class TimeTableRepository : MySQLRepository<TimeTable, long>, ITimeTableRepository
    {
        private const string ENTITY_NAME = "TimeTable";
        public TimeTableRepository(IMySQLStream<TimeTable> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<TimeTable>())
        {
        }

        
    }
}
