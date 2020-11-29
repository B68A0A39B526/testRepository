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
        public string Name { get; set; }
        public long Id { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
        public virtual Address Address { get; set; }
        private List<Room> _room;
        public virtual List<Room> Room
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
        public virtual List<Employee> Employee
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
            Id = id;
        }

        public Hospital(string name, Address address, string telephone, string website, List<Room> room, List<Employee> employee)
        {
            Name = name;
            Telephone = telephone;
            Website = website;
            Room = room;
            Employee = employee;
            Address = address;
        }

        public Hospital(long id, string name, Address address, string telephone, string website, List<Room> room, List<Employee> employee)
        {
            Id = id;
            Name = name;
            Telephone = telephone;
            Website = website;
            Room = room;
            Employee = employee;
            Address = address;
        }

        public Hospital(string name, Address address, string telephone, string website)
        {
            Name = name;
            Telephone = telephone;
            Website = website;
            Address = address;
            Room = new List<Room>();
            Employee = new List<Employee>();
        }

        public Hospital(long id, string name, Address address, string telephone, string website)
        {
            Id = id;
            Name = name;
            Telephone = telephone;
            Website = website;
            Address = address;
            Room = new List<Room>();
            Employee = new List<Employee>();
        }

        public void AddRoom(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (Room == null)
                Room = new List<Room>();
            if (!Room.Contains(newRoom))
                Room.Add(newRoom);
        }

        public void RemoveRoom(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (Room != null && Room.Contains(oldRoom))
                Room.Remove(oldRoom);
        }

        public void RemoveAllRoom()
        {
            if (Room != null)
                Room.Clear();
        }

        public void AddEmployee(Employee newEmployee)
        {
            if (newEmployee == null)
                return;
            if (Employee == null)
                Employee = new List<Employee>();
            if (!Employee.Contains(newEmployee))
            {
                Employee.Add(newEmployee);
                newEmployee.Hospital = this;
            }
        }

        public void RemoveEmployee(Employee oldEmployee)
        {
            if (oldEmployee == null)
                return;
            if (Employee != null && Employee.Contains(oldEmployee))
            {
                Employee.Remove(oldEmployee);
                oldEmployee.Hospital = null;
            }
        }

        public void RemoveAllEmployee()
        {
            if (Employee != null)
            {
                List<Employee> tmpEmployee = new List<Employee>();
                foreach (Employee oldEmployee in Employee)
                    tmpEmployee.Add(oldEmployee);
                Employee.Clear();
                foreach (Employee oldEmployee in tmpEmployee)
                    oldEmployee.Hospital = null;
                tmpEmployee.Clear();
            }
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            var hospital = obj as Hospital;
            return hospital != null &&
                   Id == hospital.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}