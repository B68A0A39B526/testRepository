using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class RoomStatisticsRepository : MySQLRepository<StatsRoom, long>, IRoomStatisticsRepository, IEagerRepository<StatsRoom, long>
    {
        private const string ENTITY_NAME = "Room Statistics Repository";
        private string[] INCLUDE_PROPERTIES = { "Room" };

        public RoomStatisticsRepository(IMySQLStream<StatsRoom> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<StatsRoom>())
        {
        }

        public IEnumerable<StatsRoom> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);

        public StatsRoom GetEager(long id)
            => GetAllEager().SingleOrDefault(stat => stat.GetId() == id);

        public IEnumerable<StatsRoom> GetRoomStatistics()
            => GetAll();

        public StatsRoom GetStatisticsByRoom(Room room)
            => GetAll().SingleOrDefault(stat => stat.Room.GetId() == room.GetId());

    }
}
