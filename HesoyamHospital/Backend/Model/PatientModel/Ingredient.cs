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
        public string Name { get; set; }
        public long Id { get; set; }


        public Ingredient(long id)
        {
            Id = id;
        }

        public Ingredient(long id, string name)
        {
            Id = id;
            Name = name;
        }
       
        public long GetId()
            => Id;

        public void SetId(long id)
            => Id = id;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Ingredient otherDisease = obj as Ingredient;
            return Id == otherDisease.GetId();
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}