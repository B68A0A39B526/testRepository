// File:    DoctorFilter.cs
// Author:  Geri
// Created: 22. maj 2020 11:38:25
// Purpose: Definition of Class DoctorFilter

using Backend.Model.DoctorModel;
using System;

namespace Backend.Util
{
    public class DoctorFilter
    {
        private string _name;
        private string _surname;
        private DoctorType _type;

        public DoctorFilter(string name, string surname, DoctorType type)
        {
            _name = name;
            _surname = surname;
            _type = type;
        }

        public DoctorType Type { get => _type; set => _type = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Name { get => _name; set => _name = value; }
    }
}