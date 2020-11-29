/***********************************************************************
 * Module:  Allergy.cs
 * Author:  nikola
 * Purpose: Definition of the Class Allergy
 ***********************************************************************/

using System;
using Backend.Repository.Abstract;
using System.Collections.Generic;

namespace Backend.Model.PatientModel
{
    public class Allergy : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Allergy() { }
        public Allergy(long id)
        {
            Id = id;
            Name = "";
            
        }

        public Allergy(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            var allergy = obj as Allergy;
            return allergy != null &&
                   Id == allergy.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}