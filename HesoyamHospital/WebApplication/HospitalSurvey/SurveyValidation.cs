using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.HospitalSurvey
{
    public static class SurveyValidation
    {
        
        public static bool IsNewSurveyValid(SurveyDTO dto)
        {
            if( dto == null)
            {
                return false;
            }
            if(dto.AnswerOne>=1 && dto.AnswerOne<=5 && dto.AnswerTwo >= 1 && dto.AnswerTwo <= 5 &&
                dto.AnswerThree >= 1 && dto.AnswerThree <= 5 && dto.AnswerFour >= 1 && dto.AnswerFour <= 5 &&
                dto.AnswerFive>= 1 && dto.AnswerFive <= 5 && dto.AnswerSix >= 1 && dto.AnswerSix <= 5 &&
                dto.AnswerSeven >= 1 && dto.AnswerSeven <= 5 && dto.AnswerEight >= 1 && dto.AnswerEight <= 5 &&
                dto.AnswerNine >= 1 && dto.AnswerNine <= 5 && dto.AnswerTen >= 1 && dto.AnswerTen <= 5 &&
                dto.AnswerEleven >= 1 && dto.AnswerEleven <= 5 && dto.AnswerTwelve >= 1 && dto.AnswerTwelve <= 5 &&
                dto.AnswerThirteen >= 1 && dto.AnswerThirteen <= 5 && dto.AnswerFourteen >= 1 && dto.AnswerFourteen <= 5 &&
                dto.AnswerSixteen >= 1 && dto.AnswerSixteen <= 5 && dto.AnswerFifteen >= 1 && dto.AnswerFifteen <= 5)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
