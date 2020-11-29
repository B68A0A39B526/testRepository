// File:    Diagnosis.cs
// Author:  Windows 10
// Created: 16. april 2020 18:22:13
// Purpose: Definition of Class Diagnosis

using System;
using System.Collections.Generic;
using Backend.Repository.Abstract;
using System.Linq;

namespace Backend.Model.PatientModel
{
    public class Diagnosis : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisName { get; set; }


        public Diagnosis(long id)
        {
            Id = id;
        }

        public Diagnosis(long id, string diagnosisName, string diagnosisCode)
        {
            Id = id;
            DiagnosisName = diagnosisName;
            DiagnosisCode = diagnosisCode;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            var diagnosis = obj as Diagnosis;
            return diagnosis != null &&
                   Id == diagnosis.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}