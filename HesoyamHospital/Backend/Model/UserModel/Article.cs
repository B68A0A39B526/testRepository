// File:    Article.cs
// Author:  Geri
// Created: 18. april 2020 19:55:51
// Purpose: Definition of Class Article

using System;

namespace Backend.Model.UserModel
{
    public class Article : Content
    {
        private string _title;
        public string Title { get => _title; set => _title = value; }

        private string _shortDescription;
        public string ShortDescription { get => _title; set => _title = value; }

        public Employee _author;
        public Employee Author { get { return _author; } set { _author = value; _authorID = value.Id; } }

        private long _authorID;
        public long AuthorID { get => _authorID; set => _authorID = value; }


        public Article(string title, string shortDescription, string text, Employee author, DateTime dateCreated) : base(text, dateCreated)
        {
            _title = title;
            _shortDescription = shortDescription;
            _author = author;
            _authorID = author.Id;
        }

        public Article(string title, string shortDescription, string text, Employee author) : base(text)
        {
            _title = title;
            _shortDescription = shortDescription;
            _author = author;
            _authorID = author.Id;
        }

        public Article(long id, string title, string shortDescription, string text, Employee author, DateTime dateCreated) : base(id, text, dateCreated)
        {
            _title = title;
            _shortDescription = shortDescription;
            _author = author;
            _authorID = author.Id;
        }

        public Article(long id) : base(id) { }

    }
}