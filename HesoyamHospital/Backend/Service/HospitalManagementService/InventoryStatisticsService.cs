using Backend.Exceptions;
using Backend.Model.ManagerModel;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.HospitalManagementService
{
    public class InventoryStatisticsService : IService<StatsInventory, long>
    {

        private InventoryStatisticsRepository _inventoryStatisticsRepository;

        public InventoryStatisticsService(InventoryStatisticsRepository inventoryStatisticsRepository)
        {
            _inventoryStatisticsRepository = inventoryStatisticsRepository;
        }

        public StatsInventory Create(StatsInventory entity)
        {
            Validate(entity);
            return _inventoryStatisticsRepository.Create(entity);
        }

        public void Delete(StatsInventory entity)
            => _inventoryStatisticsRepository.Delete(entity);

        public IEnumerable<StatsInventory> GetAll()
            => _inventoryStatisticsRepository.GetAllEager();

        public StatsInventory GetByID(long id)
            => this.GetAll().SingleOrDefault(stat => stat.GetId() == id);

        public void Update(StatsInventory entity)
        {
            Validate(entity);
            _inventoryStatisticsRepository.Update(entity);
        }

        public void Validate(StatsInventory entity)
        {
            CheckUsage(entity);
        }

        private void CheckUsage(StatsInventory entity)
        {
            if (entity.Usage < 0)
            {
                throw new InventoryStatisticServiceException("InventoryStatisticsService - usage is less than zero!");
            }
        }
    }
}
