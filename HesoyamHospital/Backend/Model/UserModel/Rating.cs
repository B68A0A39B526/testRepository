// File:    Rating.cs
// Author:  Geri
// Created: 18. april 2020 20:35:26
// Purpose: Definition of Class Rating

using Backend.Repository.Abstract;
using System;

namespace Backend.Model.UserModel
{
    public class Rating
    {
        public long Id { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }


        public Rating(string comment, int stars)
        {
            Comment = comment;
            Stars = stars;
        }

        public Rating() { }
    }
}