using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IRoomStatisticsRepository
    {
        StatsRoom GetStatisticsByRoom(Room room);

        IEnumerable<StatsRoom> GetRoomStatistics();

    }
}
