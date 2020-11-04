using Backend.Model.ManagerModel;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.HospitalManagementService
{
    public class RoomStatisticsService : IService<StatsRoom, long>
    {
        private RoomStatisticsRepository _roomStatisticsRepository;

        public RoomStatisticsService(RoomStatisticsRepository roomStatisticsRepository)
        {
            _roomStatisticsRepository = roomStatisticsRepository;
        }

        public StatsRoom Create(StatsRoom entity)
        {
            Validate(entity);
            return _roomStatisticsRepository.Create(entity);
        }

        public void Delete(StatsRoom entity)
            => _roomStatisticsRepository.Delete(entity);

        public IEnumerable<StatsRoom> GetAll()
            => _roomStatisticsRepository.GetAllEager();

        public StatsRoom GetByID(long id)
            => this.GetAll().SingleOrDefault(stat => stat.GetId() == id);

        public void Update(StatsRoom entity)
        {
            Validate(entity);
            _roomStatisticsRepository.Update(entity);
        }

        public void Validate(StatsRoom entity)
        {
            CheckAppointmentTime(entity.AvgAppointmentTime);
            CheckTimeOccupied(entity.TimeOccupied);
            CheckUsage(entity.Usage);
        }

        private void CheckUsage(double usage)
        {
            if (usage < 0)
                throw new RoomStatisticServiceException("Usage is less than zero!");
        }

        private void CheckTimeOccupied(double timeOccupied)
        {
            if (timeOccupied < 0)
                throw new RoomStatisticServiceException("TimeOccupied is less than zero!");
        }

        private void CheckAppointmentTime(int avgAppointmentTime)
        {
            if (avgAppointmentTime < 0)
                throw new RoomStatisticServiceException("AvgAppointmentTime is less than zero!");
        }
    }
}
