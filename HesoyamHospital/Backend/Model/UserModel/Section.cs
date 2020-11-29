using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class Section : IIdentifiable<long>
    {
        public long Id { get; set; }
        public long AnswerOne { get; set; }
        public long AnswerTwo { get; set; }
        public long AnswerThree { get; set; }
        public long AnswerFour { get; set; }

        public Section()
        {
        }

        public Section(long id)
        {
            Id = id;
        }

        public Section(long id, long answerOne, long answerTwo, long answerThree, long answerFour)
        {
            Id = id;
            AnswerOne = answerOne;
            AnswerTwo = answerTwo;
            AnswerThree = answerThree;
            AnswerFour = answerFour;
        }
        public Section(long answerOne, long answerTwo, long answerThree, long answerFour)
        {
            
            AnswerOne = answerOne;
            AnswerTwo = answerTwo;
            AnswerThree = answerThree;
            AnswerFour = answerFour;
        }
        public long GetId()
            => Id;

        public void SetId(long id)
            => Id = id;
    }
}
