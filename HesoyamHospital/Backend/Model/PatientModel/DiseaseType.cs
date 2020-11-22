/***********************************************************************
 * Module:  DiseaseType.cs
 * Author:  nikola
 * Purpose: Definition of the Class DiseaseType
 ***********************************************************************/

using System;

namespace Backend.Model.PatientModel
{
    public class DiseaseType
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private bool infectious;
        public bool Infectious { get => infectious; set => infectious = value; }

        private bool genetic;
        public bool Genetic { get => genetic; set => genetic = value; }

        private string type;
        public string Type { get => type; set => type = value; }

        public DiseaseType(bool infectious, bool genetic, string type)
        {
            this.Infectious = infectious;
            this.Genetic = genetic;
            this.Type = type;
        }

        
       
        
    }


}