/***********************************************************************
 * Module:  Symptom.cs
 * Author:  nikola
 * Purpose: Definition of the Class Symptom
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Backend.Repository.Abstract;

namespace Backend.Model.PatientModel
{
    public class Symptom : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }

        public long GetId()
            => Id;

        public void SetId(long id)
            => Id = id;


        public Symptom(long id){
            Id = id;
        }

        public Symptom(long id, string name, string shortDescription)
        {
            Id = id;
            Name = name;
            ShortDescription = shortDescription;
        }

        public Symptom(string name, string shortDescription)
        {
            Name = name;
            ShortDescription = shortDescription;
        }

        public override bool Equals(object obj)
        {
            var symptom = obj as Symptom;
            return symptom != null &&
                   Id == symptom.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}