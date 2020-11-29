using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.HospitalSurvey
{
    public class MeanDTO
    {
        public double AnswerOne { get; set; }
        public double AnswerTwo { get; set; }
        public double AnswerThree { get; set; }
        public double AnswerFour { get; set; }

        public MeanDTO(double answerOne, double answerTwo, double answerThree, double answerFour)
        {

            AnswerOne = answerOne;
            AnswerTwo = answerTwo;
            AnswerThree = answerThree;
            AnswerFour = answerFour;

        }
        public MeanDTO() { }
    }
}

