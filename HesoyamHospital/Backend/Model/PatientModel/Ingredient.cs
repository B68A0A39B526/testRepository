/***********************************************************************
 * Module:  Ingredients.cs
 * Author:  nikola
 * Purpose: Definition of the Class Ingredients
 ***********************************************************************/

using System;
using Backend.Repository.Abstract;

namespace Backend.Model.PatientModel
{
    public class Ingredient : IIdentifiable<long>
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private long _id;
        public long Id { get => _id; set => _id = value; }


        public Ingredient(long id)
        {
            _id = id;
        }

        public Ingredient(long id, string name)
        {
            _id = id;
            _name = name;
        }
       
        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Ingredient otherDisease = obj as Ingredient;
            return _id == otherDisease.GetId();
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}