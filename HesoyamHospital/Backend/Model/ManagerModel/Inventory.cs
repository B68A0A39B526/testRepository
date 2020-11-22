/***********************************************************************
 * Module:  Inventory.cs
 * Author:  vule
 * Purpose: Definition of the Class Inventory
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;
using Backend.Repository.Abstract;

namespace Backend.Model.ManagerModel
{
    public class Inventory: IIdentifiable<long>
    {
        private long _id;

        public long Id { get => _id; set => _id = value; }
        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }

        private List<InventoryItem> _inventoryItem;
        public List<InventoryItem> InventoryItem
        {
            get
            {
                if (_inventoryItem == null)
                    _inventoryItem = new List<InventoryItem>();
                return _inventoryItem;
            }
            set
            {
                RemoveAllInventoryItem();
                if (value != null)
                {
                    foreach (InventoryItem oInventoryItem in value)
                        AddInventoryItem(oInventoryItem);
                }
            }
        }
        public List<Medicine> medicine;

        public List<Medicine> Medicine
        {
            get
            {
                if (medicine == null)
                    medicine = new System.Collections.Generic.List<Medicine>();
                return medicine;
            }
            set
            {
                RemoveAllMedicine();
                if (value != null)
                {
                    foreach (Medicine oMedicine in value)
                        AddMedicine(oMedicine);
                }
            }
        }

        public Inventory(long id)
        {
            _id = id;
            _inventoryItem = new List<InventoryItem>();
            medicine = new List<Medicine>();
        }

        public Inventory(long id, List<InventoryItem> inventoryItem, List<Medicine> medicine)
        {
            this._id = id;
            this._inventoryItem = inventoryItem;
            this.medicine = medicine;
        }
      

        /// <summary>
        /// Property for collection of Model.Patient.Medicine
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
       

        /// <summary>
        /// Add a new Model.Patient.Medicine in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddMedicine(Medicine newMedicine)
        {
            if (newMedicine == null)
                return;
            if (medicine == null)
                medicine = new List<Medicine>();
            if (!medicine.Contains(newMedicine))
                medicine.Add(newMedicine);
        }

        /// <summary>
        /// Remove an existing Model.Patient.Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveMedicine(Medicine oldMedicine)
        {
            if (oldMedicine == null)
                return;
            if (medicine != null)
                if (medicine.Contains(oldMedicine))
                    medicine.Remove(oldMedicine);
        }

        /// <summary>
        /// Remove all instances of Model.Patient.Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllMedicine()
        {
            if (medicine != null)
                medicine.Clear();
        }
        

        /// <summary>
        /// Property for collection of InventoryItem
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        

        /// <summary>
        /// Add a new InventoryItem in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddInventoryItem(InventoryItem newInventoryItem)
        {
            if (newInventoryItem == null)
                return;
            if (_inventoryItem == null)
                _inventoryItem = new List<InventoryItem>();
            if (!_inventoryItem.Contains(newInventoryItem))
                _inventoryItem.Add(newInventoryItem);
        }

        /// <summary>
        /// Remove an existing InventoryItem from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveInventoryItem(InventoryItem oldInventoryItem)
        {
            if (oldInventoryItem == null)
                return;
            if (_inventoryItem != null)
                if (_inventoryItem.Contains(oldInventoryItem))
                    _inventoryItem.Remove(oldInventoryItem);
        }

        /// <summary>
        /// Remove all instances of InventoryItem from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllInventoryItem()
        {
            if (_inventoryItem != null)
                _inventoryItem.Clear();
        }

       

        public override bool Equals(object obj)
        {
            var inventory = obj as Inventory;
            return inventory != null &&
                   _id == inventory._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}