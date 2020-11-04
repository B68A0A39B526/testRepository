// File:    TherapyFilter.cs
// Author:  nikola
// Created: 21. maj 2020 15:56:47
// Purpose: Definition of Class TherapyFilter

using System;
using System.Collections.Generic;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;

namespace Backend.Util
{
    public class TherapyFilter
    {
        private string _drugName;
        private Doctor _doctor;
        private TimeInterval _timeInterval;
        private IEnumerable<TherapyTime> _therapyTimes;

        public TherapyFilter(string drugName, Doctor doctor, TimeInterval timeInterval, List<TherapyTime> therapyTimes)
        {
            _drugName = drugName;
            _timeInterval = timeInterval;
            _therapyTimes = therapyTimes;
        }
        public string DrugName { get => _drugName; set => _drugName = value; }
        public TimeInterval TimeInterval { get => _timeInterval; set => _timeInterval = value; }
        public IEnumerable<TherapyTime> TherapyTimes { get => _therapyTimes; set => _therapyTimes = value; }
    }
}