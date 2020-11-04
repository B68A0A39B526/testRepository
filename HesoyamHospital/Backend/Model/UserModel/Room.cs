/***********************************************************************
 * Module:  Room.cs
 * Author:  vule
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Backend.Model.ManagerModel;
using Backend.Repository.Abstract;

namespace Backend.Model.UserModel
{
    public class Room: IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private string _roomNumber;
        public string RoomNumber { get => _roomNumber; set => _roomNumber = value; }

        private bool _occupied;
        public bool Occupied { get => _occupied; set => _occupied = value; }

        private int _floor;
        public int Floor { get => _floor; set => _floor = value; }

        private RoomType _roomType;
        public RoomType RoomType { get => _roomType; set => _roomType = value; }

        public Room(long id)
        {
            _id = id;
        }
        

        public Room(string roomNumber, bool occupied, int floor, RoomType roomType)
        {
            _roomNumber = roomNumber;
            _occupied = occupied;
            _floor = floor;
            _roomType = roomType;
        }

        public Room(long id, string roomNumber, bool occupied, int floor, RoomType roomType)
        {
            _id = id;
            _roomNumber = roomNumber;
            _occupied = occupied;
            _floor = floor;
            _roomType = roomType;
        }

        public override bool Equals(object obj)
        {
            var room = obj as Room;
            return room != null &&
                   _id == room._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;
    }
}