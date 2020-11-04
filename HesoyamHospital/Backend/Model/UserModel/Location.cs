// File:    Location.cs
// Author:  Geri
// Created: 19. april 2020 20:30:46
// Purpose: Definition of Class Location

using Backend.Repository.Abstract;
using System;

namespace Backend.Model.UserModel
{
    public class Location : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private string _country;
        public string Country { get => _country; set => _country = value; }

        private string _city;
        public string City { get => _city; set => _city = value; }

        public Location(string country, string city)
        {
            _country = country;
            _city = city;
        }

        public Location(long id, string country, string city)
        {
            _id = id;
            _country = country;
            _city = city;
        }

        public Location(long id)
        {
            _id = id;
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   _id == location._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}