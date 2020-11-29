using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.HospitalSurvey
{
    public static class SectionMapper
    {
        public static SectionDTO SectionToSectionDTO(Section section)
        {
            return new SectionDTO(section.AnswerOne,section.AnswerTwo,section.AnswerThree,
                section.AnswerFour);

        }
    }
}
