// File:    MedicineFilter.cs
// Author:  nikola
// Created: 22. maj 2020 16:01:15
// Purpose: Definition of Class MedicineFilter

using Backend.Model.PatientModel;
using System;

namespace Backend.Util
{
    public class MedicineFilter
    {
        private Disease _disease;
        private string _name;
        private MedicineType _type;
        private Ingredient _ingredient;
        private double _strength;

        public MedicineFilter(Disease disease, string name, MedicineType medicineType, Ingredient ingredient, double strength)
        {
            _disease = disease;
            _name = name;
            _type = medicineType;
            _ingredient = ingredient;
            _strength = strength; 
        }
        public Disease Disease { get => _disease; set => _disease = value; }
        public string Name { get => _name; set => _name = value; }
        public MedicineType Type { get => _type; set => _type = value; }
        public Ingredient Ingredient { get => _ingredient; set => _ingredient = value; }
        public double Strength { get => _strength; set => _strength = value; }
    }
}