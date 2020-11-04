// File:    RoomService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class RoomService

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Util;

namespace Backend.Service.HospitalManagementService
{
    public class RoomService : IService<Room, long>
    {
        private RoomRepository _roomRepository;
        private AppointmentRepository _appointmentRepository;

        public RoomService(RoomRepository roomRepository, AppointmentRepository appointmentRepository)
        {
            _roomRepository = roomRepository;
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<Room> GetRoomsByType(RoomType type)
            => _roomRepository.GetRoomsByType(type);

        public IEnumerable<Room> GetAvailableRoomsByDate(TimeInterval timeInterval)
        {
            var appointments = _appointmentRepository.GetAppointmentsByTime(timeInterval);
            var allRooms = GetAll().ToList();

            foreach(Appointment appointment in appointments) {
                Room appointmentRoom = appointment.Room;
                if(appointmentRoom != null)
                    allRooms.Remove(allRooms.First(r => r.GetId() == appointmentRoom.GetId()));
            }
            return allRooms;
        }

        public void DivideRooms(Room initialRoom, String newNumber)
        {
            initialRoom.RoomNumber = newNumber;
            _roomRepository.Create(initialRoom);
        }

        public Room MergeRooms(IEnumerable<Room> roomsToMerge, string newName)
        {
            foreach(Room room in roomsToMerge)
            {
                _roomRepository.Delete(room);
            }

            return _roomRepository.Create(new Room(newName, false, roomsToMerge.ToList()[0].Floor, roomsToMerge.ToList()[0].RoomType));

        }

        public Room GetRoomByName(string name)
            => _roomRepository.GetRoomByName(name);

        public IEnumerable<Room> GetRoomsByFloor(int floor)
            => _roomRepository.GetRoomsByFloor(floor);

        public IEnumerable<Room> GetAll()
            => _roomRepository.GetAll();

        public Room GetByID(long id)
            => this.GetAll().SingleOrDefault(room => room.GetId() == id);

        public Room Create(Room entity)
        {
            Validate(entity);
            return _roomRepository.Create(entity);
        }

        public void Update(Room entity)
        {
            Validate(entity);
            _roomRepository.Update(entity);
        }

        public void Delete(Room entity)
            => _roomRepository.Delete(entity);

        void IService<Room, long>.Update(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Room entity)
        {
            CheckFloorNumber(entity.Floor);
            CheckRoomNumber(entity.RoomNumber);
        }

        private void CheckRoomNumber(string roomNumber)
        {
            if (!Regex.Match(roomNumber, Regexes.roomNumberPattern).Success)
                throw new RoomServiceException("RoomNumber contains illegal characters!");
        }

        private void CheckFloorNumber(int floor)
        {
            if (floor < 0)
                throw new RoomServiceException("RoomService - Floor is less than zero!");
        }
    }
}