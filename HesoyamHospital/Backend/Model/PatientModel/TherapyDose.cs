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
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private List<SingleTherapyDose> _dosage;
        public List<SingleTherapyDose> Dosage { get => _dosage; set => _dosage = value; }

        public TherapyDose(List<SingleTherapyDose> dosage)
        {
            _dosage = dosage;
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;
    }
}