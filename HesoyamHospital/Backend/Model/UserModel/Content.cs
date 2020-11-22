// File:    Content.cs
// Author:  Geri
// Created: 18. april 2020 19:55:51
// Purpose: Definition of Class Content

using Backend.Repository.Abstract;
using System;

namespace Backend.Model.UserModel
{
    public class Content : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private string _text;
        public string Text { get => _text; set => _text = value; }

        private DateTime _dateCreated;
        public DateTime Date { get => _dateCreated; set => _dateCreated = value; }

        public Content(string text, DateTime dateCreated)
        {
            _dateCreated = dateCreated;
            _text = text;
        }

        public Content(string text)
        {
            _text = text;
        }

        public Content(long id, string text, DateTime dateCreated)
        {
            _id = id;
            _dateCreated = dateCreated;
            _text = text;
        }

        public Content(long id)
        {
            _id = id;
        }


        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }

        public override bool Equals(object obj)
        {
            var content = obj as Content;
            return content != null &&
                   _id == content._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}