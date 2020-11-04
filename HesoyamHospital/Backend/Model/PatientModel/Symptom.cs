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
        private long _id;
        private string _name;
        private string _shortDescription;

        public long Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string ShortDescription { get => _shortDescription; set => _shortDescription = value; }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;


        public Symptom(long id){
            _id = id;
        }

        public Symptom(long id, string name, string shortDescription)
        {
            _id = id;
            _name = name;
            _shortDescription = shortDescription;
        }

        public Symptom(string name, string shortDescription)
        {
            _name = name;
            _shortDescription = shortDescription;
        }

        public override bool Equals(object obj)
        {
            var symptom = obj as Symptom;
            return symptom != null &&
                   _id == symptom._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}