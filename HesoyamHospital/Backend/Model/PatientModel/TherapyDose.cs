// File:    TherapyDose.cs
// Author:  nikola
// Created: 24. maj 2020 10:53:22
// Purpose: Definition of Class TherapyDose

using Backend.Model.UserModel;
using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Model.PatientModel
{
    public class TherapyDose : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual List<SingleTherapyDose> Dosage { get; set; }

        public TherapyDose()
        {

        }

        public TherapyDose(List<SingleTherapyDose> dosage)
        {
            Dosage = dosage;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}