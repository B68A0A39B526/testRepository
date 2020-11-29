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
        public long Id {get; set;}
        public virtual User User { get; set; }
        public bool Published { get; set; }
        public bool Anonymous { get; set; }
        public bool Public { get; set; }
        public string Comment { get; set; }

        private List<QuestionAnswer> _rating;
        public virtual List<QuestionAnswer> Rating
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

        public long GetId() => Id;
        public void SetId(long id) => Id = id;

        public Feedback(User user, string comment)
        {
            User = user;
            Comment = comment;
            Rating = new List<QuestionAnswer>();
        }

        public Feedback(long id, User user, string comment)
        {
            Id = id;
            User = user;
            Comment = comment;
            Rating = new List<QuestionAnswer>();
        }

        public Feedback(User user, string comment, List<QuestionAnswer> rating)
        {
            User = user;
            Comment = comment;
            if (rating == null)
                Rating = new List<QuestionAnswer>();
            else
                Rating = rating;
        }

        public Feedback(long id, User user, string comment, List<QuestionAnswer> rating)
        {
            Id = id;
            User = user;
            Comment = comment;
            if (rating == null)
                Rating = new List<QuestionAnswer>();
            else
                Rating = rating;
        }

        public Feedback(long id)
        {
            Id = id;
            Rating = new List<QuestionAnswer>();
        }

        public Feedback(User _user, string _comment, bool _anonymous, bool _public)
        {
            User = _user;
            Comment = _comment;
            Anonymous = _anonymous;
            Public = _public;
        }
        public Feedback() { }
        
        public void AddRating(QuestionAnswer qa)
        {
            if (qa == null)
                return;
            if (qa.Rating == null)
                qa.Rating = new Rating();
            if (Rating == null)
                Rating = new List<QuestionAnswer>();
            if (Rating.Find(qatemp => qatemp.Question.Equals(qa.Question)) == null)
                Rating.Add(qa);
        }

        public void RemoveRating(QuestionAnswer qa)
        {
            if (qa == null)
                return;
            if (Rating != null && Rating.Contains(qa))
                Rating.Remove(qa);
        }

        public void RemoveAllRating()
        {
            if (Rating != null)
                Rating.Clear();
        }

        public override bool Equals(object obj)
        {
            var feedback = obj as Feedback;
            return feedback != null &&
                   Id == feedback.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}