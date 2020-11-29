using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.HospitalSurvey
{
    public class SectionDTO
    {
        public long AnswerOne { get; set; }
        public long AnswerTwo { get; set; }
        public long AnswerThree { get; set; }
        public long AnswerFour { get; set; }

        public SectionDTO(long answerOne, long answerTwo, long answerThree, long answerFour)
        {

            AnswerOne = answerOne;
            AnswerTwo = answerTwo;
            AnswerThree = answerThree;
            AnswerFour = answerFour;
         
        }
        public SectionDTO () { }
    }
}
