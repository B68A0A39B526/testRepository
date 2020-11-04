// File:    StatsRoom.cs
// Author:  vule
// Created: 18. april 2020 17:15:52
// Purpose: Definition of Class StatsRoom

using Backend.Model.UserModel;
using System;
using System.Collections.Generic;

namespace Backend.Model.ManagerModel
{
    public class StatsRoom : Stats
    {
        private double _usage;
        private double _timeOccupied;
        private int _avgAppointmentTime;

        private Room _room;
        private long _roomID;

        public long RoomID { get => _roomID; set => _roomID = value; }

        public int AvgAppointmentTime { get { return _avgAppointmentTime; } set { _avgAppointmentTime = value; } }
        public double Usage { get { return _usage; } set { } }

        public double TimeOccupied { get { return _timeOccupied; } set { } }


        /// <summary>
        /// Property for collection of Model.User.Room
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public Room Room
        {
            get
            {
                if (_room == null)
                    return null;
                return _room;
            }
            set
            {
                
                if (value != null)
                {
                    _room = value;
                    _roomID = value.Id;
                }
            }
        }

        public StatsRoom(double usage, double timeOccupied, int avgAppointmentTime, Room room): base()
        {
            _usage = usage;
            _timeOccupied = timeOccupied;
            _avgAppointmentTime = avgAppointmentTime;
            _room = room;
            _roomID = room.Id;
        }

        public StatsRoom(long id, double usage, double timeOccupied, int avgAppointmentTime, Room room) : base(id)
        {
            _usage = usage;
            _timeOccupied = timeOccupied;
            _avgAppointmentTime = avgAppointmentTime;
            _room = room;
            _roomID = room.Id;
        }

        public StatsRoom(long id): base(id)
        {

        }

        
    }
}