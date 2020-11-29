using Backend.Model.PatientModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Specifications.Converter;
using Backend.Util;
using System;
using System.Collections.Generic;

using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System.Linq;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class InventoryItemRepository : MySQLRepository<InventoryItem, long>, IInventoryItemRepository, IEagerRepository<InventoryItem, long>
    {
        private const string ENTITY_NAME = "InventoryItem";
        public InventoryItemRepository(IMySQLStream<InventoryItem> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<InventoryItem>()) { }

        public IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room)
            => GetAll().ToList().Where(item => item.Room.Equals(room));

        public IEnumerable<InventoryItem> GetInventoryItems()
            => GetAll();
    }
}
