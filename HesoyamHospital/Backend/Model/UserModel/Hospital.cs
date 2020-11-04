// File:    Hospital.cs
// Author:  Windows 10
// Created: 19. april 2020 22:03:33
// Purpose: Definition of Class Hospital

using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;


namespace Backend.Model.UserModel
{
    public class Hospital : IIdentifiable<long>
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private long _id;
        public long Id { get => _id ; set => _id = value; }

        private string _telephone;
        public string Telephone { get => _telephone; set => _telephone = value; }

        private string _website;
        public string Website { get => _website; set => _website = value; }

        private Address _address;
        public Address Address { get => _address; set { _address = value; _addressID = value.Id; } }

        private long _addressID;
        public long AddressID { get => _addressID; set => _addressID = value; }

        private List<Room> _room;
        public List<Room> Room
        {
            get
            {
                if (_room == null)
                    _room = new List<Room>();
                return _room;
            }
            set
            {
                RemoveAllRoom();
                if (value != null)
                {
                    foreach (Room oRoom in value)
                        AddRoom(oRoom);
                }
            }
        }

        private List<Employee> _employee;
        public List<Employee> Employee
        {
            get
            {
                if (_employee == null)
                    _employee = new List<Employee>();
                return _employee;
            }
            set
            {
                RemoveAllEmployee();
                if (value != null)
                {
                    foreach (Employee oEmployee in value)
                        AddEmployee(oEmployee);
                }
            }
        }

        public Hospital()
        {

        }
        public Hospital(long id)
        {
            _id = id;
        }

        public Hospital(string name, Address address, string telephone, string website, List<Room> room, List<Employee> employee)
        {
            _name = name;
            _telephone = telephone;
            _website = website;
            _room = room;
            _employee = employee;
            _address = address;
            _addressID = address.Id;
        }

        public Hospital(long id, string name, Address address, string telephone, string website, List<Room> room, List<Employee> employee)
        {
            _id = id;
            _name = name;
            _telephone = telephone;
            _website = website;
            _room = room;
            _employee = employee;
            _address = address;
            _addressID = address.Id;
        }

        public Hospital(string name, Address address, string telephone, string website)
        {
            _name = name;
            _telephone = telephone;
            _website = website;
            _address = address;
            _addressID = address.Id;
            _room = new List<Room>();
            _employee = new List<Employee>();
        }

        public Hospital(long id, string name, Address address, string telephone, string website)
        {
            _id = id;
            _name = name;
            _telephone = telephone;
            _website = website;
            _address = address;
            _addressID = address.Id;
            _room = new List<Room>();
            _employee = new List<Employee>();
        }

        public void AddRoom(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (_room == null)
                _room = new List<Room>();
            if (!_room.Contains(newRoom))
                _room.Add(newRoom);
        }

        public void RemoveRoom(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (_room != null)
                if (_room.Contains(oldRoom))
                    _room.Remove(oldRoom);
        }

        public void RemoveAllRoom()
        {
            if (_room != null)
                _room.Clear();
        }

        public void AddEmployee(Employee newEmployee)
        {
            if (newEmployee == null)
                return;
            if (_employee == null)
                _employee = new List<Employee>();
            if (!_employee.Contains(newEmployee))
            {
                _employee.Add(newEmployee);
                newEmployee.Hospital = this;
            }
        }

        public void RemoveEmployee(Employee oldEmployee)
        {
            if (oldEmployee == null)
                return;
            if (_employee != null)
                if (_employee.Contains(oldEmployee))
                {
                    _employee.Remove(oldEmployee);
                    oldEmployee.Hospital = null;
                }
        }

        public void RemoveAllEmployee()
        {
            if (_employee != null)
            {
                List<Employee> tmpEmployee = new List<Employee>();
                foreach (Employee oldEmployee in _employee)
                    tmpEmployee.Add(oldEmployee);
                _employee.Clear();
                foreach (Employee oldEmployee in tmpEmployee)
                    oldEmployee.Hospital = null;
                tmpEmployee.Clear();
            }
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            var hospital = obj as Hospital;
            return hospital != null &&
                   _id == hospital._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}