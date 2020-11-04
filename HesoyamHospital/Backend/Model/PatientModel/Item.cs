// File:    Item.cs
// Author:  vule
// Created: 18. april 2020 16:49:38
// Purpose: Definition of Class Item

using System;
using Backend.Repository.Abstract;

namespace Backend.Model.PatientModel
{
    public abstract class Item : IIdentifiable<long>
    {
        private string _name;
        private int _inStock;
        private int _minNumber;
        private long _id;

        public string Name { get => _name; set => _name = value; }
        public int InStock { get => _inStock; set => _inStock = value; }
        public int MinNumber { get => _minNumber; set => _minNumber = value; }
        public long Id { get => _id; set => _id = value; }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;

        public Item(long id)
        {
            _id = id;
        }

        public Item(string name,int inStock, int minNumber)
        {
            _name = name;
            _inStock = inStock;
            _minNumber = minNumber;
        }

        public Item(long id, string name, int inStock, int minNumber)
        {
            _id = id;
            _name = name;
            _inStock = inStock;
            _minNumber = minNumber;
        }


        public override bool Equals(object obj)
        {
            var item = obj as Item;
            return item != null &&
                   _id == item._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }

    }
}