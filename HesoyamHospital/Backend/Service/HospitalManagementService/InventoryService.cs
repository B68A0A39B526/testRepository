// File:    InventoryService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class InventoryService

using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;

namespace Backend.Service.HospitalManagementService
{
    public class InventoryService : IService<Inventory, long>
    {

        private InventoryRepository _inventoryRepository;
        private InventoryItemRepository _inventoryItemRepository;
        private MedicineRepository _medicineRepository;
        
        public InventoryService(InventoryRepository inventoryRepository, InventoryItemRepository inventoryItemRepository, MedicineRepository medicineRepository)
        {
            _inventoryRepository = inventoryRepository;
            _inventoryItemRepository = inventoryItemRepository;
            _medicineRepository = medicineRepository;
        }

        public Inventory AddInventoryItem(Inventory inventory, InventoryItem item)
            => _inventoryRepository.AddInventoryItem(inventory, item);

        public Inventory SetInventoryItem(InventoryItem inventoryItem)
            => _inventoryRepository.SetInventoryItem(inventoryItem);

        public void RemoveInventoryItem(InventoryItem item)
            => _inventoryRepository.RemoveInventoryItem(item);

        public IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room)
            => _inventoryItemRepository.GetAllEager().Where(ii => ii.Room.GetId() == room.GetId());


        public IEnumerable<Item> GetResupply()
        {
            IEnumerable<InventoryItem> items = _inventoryItemRepository.GetAllEager().Where(ii => ii.InStock <= ii.MinNumber);
            IEnumerable<Medicine> meds = _medicineRepository.GetAllEager().Where(med => med.InStock <= med.MinNumber);
            List<Item> retList = new List<Item>();
            retList.AddRange(items);
            retList.AddRange(meds);
            IEnumerable<Item> retEn = retList;
            return retEn;
        }

        public IEnumerable<InventoryItem> GetInventoryItems()
            => _inventoryItemRepository.GetAllEager();

        public IEnumerable<Inventory> GetAll()
            => _inventoryRepository.GetAllEager();

        public Inventory GetByID(long id)
            => _inventoryRepository.GetByID(id);

        public Inventory Create(Inventory entity)
            => _inventoryRepository.Create(entity);

        public void Update(Inventory entity)
            => _inventoryRepository.Update(entity);

        public void Delete(Inventory entity)
            => _inventoryRepository.Delete(entity);

        public void Validate(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public IInventoryRepository iInventoryRepository;

    }
}