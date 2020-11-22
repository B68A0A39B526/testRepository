// File:    DoctorFeedback.cs
// Author:  Geri
// Created: 18. april 2020 20:50:38
// Purpose: Definition of Class DoctorFeedback

using Backend.Model.UserModel;
using System;
using System.Collections.Generic;

namespace Backend.Model.DoctorModel
{
    public class DoctorFeedback : Feedback
    {
        private Doctor _doctor;
        public Doctor Doctor { get => _doctor; set { _doctor = value; _doctorID = value.Id; } }

        private long _doctorID;
        public long DoctorID { get => _doctorID; set => _doctorID = value;  }
        public DoctorFeedback(User user, string comment, List<QuestionAnswer> rating, Doctor doctor) : base(user, comment, rating) { 
            _doctor = doctor;
            _doctorID = doctor.Id;
        }
        public DoctorFeedback(long id, User user, string comment, List<QuestionAnswer> rating, Doctor doctor) : base(id, user, comment, rating) {
            _doctor = doctor;
            _doctorID = doctor.Id;
        }

        public DoctorFeedback(long id) : base(id)
        {
        }

       
    }
}