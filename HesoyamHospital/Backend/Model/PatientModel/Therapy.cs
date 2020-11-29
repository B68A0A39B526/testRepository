// File:    Therapy.cs
// Author:  Windows 10
// Created: 15. april 2020 22:03:13
// Purpose: Definition of Class Therapy

using Backend.Repository.Abstract;
using Backend.Util;
using System;
using System.Collections.Generic;

namespace Backend.Model.PatientModel
{
    public class Therapy : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private TimeInterval _timeInterval;
        private Prescription _prescription;
        private long _timeIntervalID;
        private long _prescriptionID;

        public long TimeIntervalID { get => _timeIntervalID; set => _timeIntervalID = value; }
        public long PrescriptionID { get => _prescriptionID; set => _prescriptionID = value; }
        public TimeInterval TimeInterval { get => _timeInterval; set { _timeInterval = value; _timeIntervalID = value.Id; } }
        public Prescription Prescription { get => _prescription; set { _prescription = value; _prescriptionID = value.Id; } }

        public Therapy(long id)
        {
            _id = id;
        }

        public Therapy(long id, TimeInterval timeInterval, Prescription prescription)
        {
            _id = id;
            _timeInterval = timeInterval;
            _prescription = prescription;
            _prescriptionID = prescription.Id;
            _timeIntervalID = timeInterval.Id;
        }

        public Therapy(TimeInterval timeInterval, Prescription prescription)
        {
            _timeInterval = timeInterval;
            _prescription = prescription;
            _prescriptionID = prescription.Id;
            _timeIntervalID = timeInterval.Id;
        }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;

        public override bool Equals(object obj)
        {
            var therapy = obj as Therapy;
            return therapy != null &&
                   _id == therapy._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}