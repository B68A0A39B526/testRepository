using Backend;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.HospitalSurvey
{
    public static class SurveyMapper
    {
        public static Survey SurveyDTOToSurvey(SurveyDTO dto)
        {
            Survey survey = new Survey();

            Section doctorSection = new Section(dto.AnswerOne, dto.AnswerTwo, dto.AnswerThree, dto.AnswerFour);
            Section staffSection= new Section(dto.AnswerFive, dto.AnswerSix, dto.AnswerSeven, dto.AnswerEight);
            Section hygieneSection = new Section(dto.AnswerNine, dto.AnswerTen, dto.AnswerEleven, dto.AnswerTwelve);
            Section equipmentSection = new Section(dto.AnswerThirteen, dto.AnswerFourteen, dto.AnswerFifteen, dto.AnswerSixteen);

            survey.Doctor = AppResources.getInstance().doctorService.GetByID(700);
            survey.DoctorSection = doctorSection;
            survey.StaffSection = staffSection;
            survey.HygieneSection = hygieneSection;
            survey.EquipmentSection = equipmentSection;

            return survey; 
        }
        public static SurveyDTO SurveyToSurveyDTO(Survey survey)
        {
            return new SurveyDTO(survey.DoctorSection.AnswerOne,survey.DoctorSection.AnswerTwo,
                survey.DoctorSection.AnswerThree, survey.DoctorSection.AnswerFour,
                survey.StaffSection.AnswerOne, survey.StaffSection.AnswerTwo,
                survey.StaffSection.AnswerThree, survey.StaffSection.AnswerFour,
                survey.HygieneSection.AnswerOne, survey.HygieneSection.AnswerTwo,
                survey.HygieneSection.AnswerThree, survey.HygieneSection.AnswerFour,
                survey.EquipmentSection.AnswerOne, survey.EquipmentSection.AnswerTwo,
                survey.EquipmentSection.AnswerThree, survey.EquipmentSection.AnswerFour);

        }
    }
}
