// File:    InventoryItem.cs
// Author:  vule
// Created: 18. april 2020 16:53:25
// Purpose: Definition of Class InventoryItem

using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using System;

namespace Backend.Model.ManagerModel
{
    public class InventoryItem : Item
    {
        private Room _room;
        public Room Room { get { return _room; } set { _room = value; _roomID = value.Id; } }

        private long _roomID;
        public long RoomID { get => _roomID; set => _roomID = value; }

        public InventoryItem(string name, int inStock, int minNumber, Room room) : base(name, inStock, minNumber)
        {
            _room = room;
            _roomID = room.Id;
        }

        public InventoryItem(long id,string name, int inStock, int minNumber, Room room) : base(id ,name, inStock, minNumber)
        {
            _room = room;
            _roomID = room.Id;
        }

        public InventoryItem(long id) : base(id) { }
    }
}