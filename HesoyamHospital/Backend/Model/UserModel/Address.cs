// File:    Address.cs
// Author:  Geri
// Created: 22. maj 2020 12:12:12
// Purpose: Definition of Class Address

using Backend.Repository.Abstract;
using System;
using System.Diagnostics.Eventing.Reader;

namespace Backend.Model.UserModel
{
    public class Address : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private string _street;
        public string Street { get => _street; set => _street = value; }

        private Location _location;
        public Location Location { get => _location; set { _location = value; _locationID = value.Id; } }

        private long _locationID;
        public long LocationID { get => _locationID; set => _locationID = value; }

        public Address() { }
        public Address(string street, Location location)
        {
            _street = street;
            _location = location;
            _locationID = location.Id;
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;
    }
}