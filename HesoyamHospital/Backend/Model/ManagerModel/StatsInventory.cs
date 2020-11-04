// File:    StatsInventory.cs
// Author:  vule
// Created: 18. april 2020 17:13:16
// Purpose: Definition of Class StatsInventory

using Backend.Model.PatientModel;
using System;

namespace Backend.Model.ManagerModel
{
    public class StatsInventory : Stats
    {
        private double _usage;

        private Medicine _medicine;
        private InventoryItem _inventoryItem;
        private long _medicineID;
        private long _inventoryItemID;
        public long MedicineID { get => _medicineID; set => _medicineID = value; }
        public long InventoryItemID { get => _inventoryItemID; set => _inventoryItemID = value; }
        public double Usage { get { return _usage; } set { _usage = value; } }

        public Medicine Medicine { get { return _medicine; } set { _medicine = value; _medicineID = value.Id; } }

        public InventoryItem InventoryItem { get { return _inventoryItem; } set { _inventoryItem = value; _inventoryItemID = value.Id; } }

        public StatsInventory(double usage, Medicine medicine, InventoryItem inventoryItem): base()
        {
            _usage = usage;
            _medicine = medicine;
            _inventoryItem = inventoryItem;
            _medicineID = medicine.Id;
            _inventoryItemID = inventoryItem.Id;
        }

        public StatsInventory(long id, double usage, Medicine medicine, InventoryItem inventoryItem) : base(id)
        {
            _usage = usage;
            _medicine = medicine;
            _inventoryItem = inventoryItem;
            _medicineID = medicine.Id;
            _inventoryItemID = inventoryItem.Id;
        }

        public StatsInventory(long id): base(id)
        {

        }
    }
}