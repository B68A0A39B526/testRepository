// File:    Feedback.cs
// Author:  Geri
// Created: 18. april 2020 20:34:11
// Purpose: Definition of Class Feedback

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Repository.Abstract;

namespace Backend.Model.UserModel
{
    public class Feedback : IIdentifiable<long>
    {
        private long _id;
        public long Id {get => _id; set => _id = value;}

        private User _user;
        public User User { get => _user; set { _user = value; _userId = value.Id; } }

        private long _userId;
        public long UserId { get => _userId; set => _userId = value; }

        private bool _published;
        public bool Published { get => _published; set => _published = value; }

        private bool _anonymous;
        public bool Anonymous { get => _anonymous ; set => _anonymous = value; }

        private bool _public;
        public bool Public { get => _public; set => _public = value; }

        private string _comment;
        public string Comment { get => _comment; set => _comment = value; }

        private List<QuestionAnswer> _rating;
        public List<QuestionAnswer> Rating
        {
            get
            {
                if (_rating == null)
                    _rating = new List<QuestionAnswer>();
                return _rating;
            }
            set
            {
                RemoveAllRating();
                if (value != null)
                {
                    foreach (QuestionAnswer qa in value)
                        AddRating(qa);
                }
            }
        }

        public long GetId() => _id;
        public void SetId(long id) => _id = id;

        public Feedback(User user, string comment)
        {
            _user = user;
            _userId = user.Id;
            _comment = comment;
            _rating = new List<QuestionAnswer>();
        }

        public Feedback(long id, User user, string comment)
        {
            _id = id;
            _user = user;
            _userId = user.Id;
            _comment = comment;
            _rating = new List<QuestionAnswer>();
        }

        public Feedback(User user, string comment, List<QuestionAnswer> rating)
        {
            _user = user;
            _userId = user.Id;
            _comment = comment;
            if (rating == null)
                _rating = new List<QuestionAnswer>();
            else
                _rating = rating;
        }

        public Feedback(long id, User user, string comment, List<QuestionAnswer> rating)
        {
            _id = id;
            _user = user;
            _userId = user.Id;
            _comment = comment;
            if (rating == null)
                _rating = new List<QuestionAnswer>();
            else
                _rating = rating;
        }

        public Feedback(long id)
        {
            _id = id;
            _rating = new List<QuestionAnswer>();
        }


        
        public void AddRating(QuestionAnswer qa)
        {
            if (qa == null)
                return;
            if (qa.Rating == null)
                qa.Rating = new Rating();
            if (_rating == null)
                _rating = new List<QuestionAnswer>();
            if (_rating.Find(qatemp => qatemp.Question.Equals(qa.Question)) == null)
                _rating.Add(qa);
        }

        public void RemoveRating(QuestionAnswer qa)
        {
            if (qa == null)
                return;
            if (_rating != null)
                if (_rating.Contains(qa))
                    _rating.Remove(qa);
        }

        public void RemoveAllRating()
        {
            if (_rating != null)
                _rating.Clear();
        }

        public override bool Equals(object obj)
        {
            var feedback = obj as Feedback;
            return feedback != null &&
                   _id == feedback._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}