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
        public long Id { get; set; }
        public bool Infectious { get; set; }
        public bool Genetic { get; set; }
        public string Type { get; set; }

        public DiseaseType(bool infectious, bool genetic, string type)
        {
            this.Infectious = infectious;
            this.Genetic = genetic;
            this.Type = type;
        }
    }
}