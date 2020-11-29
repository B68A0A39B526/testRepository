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
        public long Id { get; set; }
        public string Street { get; set; }
        public virtual Location Location { get; set; }

        public Address() { }
        public Address(string street, Location location)
        {
            Street = street;
            Location = location;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
        
        public override string ToString()
        {
            return Street +", "+  Location.ToString();
        }
    }
}