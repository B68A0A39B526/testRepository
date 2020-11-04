using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IInventoryStatisticsRepository
    {
        StatsInventory GetInventoryStatistics();

        StatsInventory GetStatisticsByItem(Item item);
    }
}
