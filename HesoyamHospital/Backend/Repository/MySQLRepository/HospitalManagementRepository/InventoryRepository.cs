// File:    InventoryRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:37
// Purpose: Definition of Class InventoryRepository

using Backend.Exceptions;
using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class InventoryRepository : MySQLRepository<Inventory, long>, IInventoryRepository, IEagerRepository<Inventory, long>
    {
        private const string ENTITY_NAME = "Inventory Repository";
        public InventoryRepository(IMySQLStream<Inventory> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Inventory>()) { }

        public Inventory AddInventoryItem(Inventory inventory, InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public Inventory SetInventoryItem(InventoryItem inventoryItem)
        {

            Inventory toUpdate = GetAll().SingleOrDefault(inventory => inventory.InventoryItem.Contains(inventoryItem));
            InventoryItem original = GetItemById(toUpdate.InventoryItem, inventoryItem.GetId());
            if(original != null)
            {
                original = inventoryItem;
                Update(toUpdate);

            } else
            {
                throw new EntityNotFoundException();
            }

            return toUpdate;
        }

        private InventoryItem GetItemById(IEnumerable<InventoryItem> items, long id)
            => items.SingleOrDefault(item => item.GetId() == id);

        public void RemoveInventoryItem(InventoryItem inventoryItem)
        {
            Inventory toUpdate = GetAll().SingleOrDefault(inventory => inventory.InventoryItem.Contains(inventoryItem));
            InventoryItem original = GetItemById(toUpdate.InventoryItem, inventoryItem.GetId());
            if (original != null)
            {
                toUpdate.InventoryItem.Remove(inventoryItem);
                Update(toUpdate);

            }
            else
            {
                throw new EntityNotFoundException();
            }

        }
    }
}