using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.UsersRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.UsersService
{
    public class SurveyService : IService<Survey, long>
    {
        private readonly SurveyRepository _surveyRepository;
        
        public SurveyService(SurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }
        

        public Survey Create(Survey entity)
        {
            Validate(entity);

            return _surveyRepository.Create(entity);
        }

        public void Delete(Survey entity)
            => _surveyRepository.Delete(entity);

        public IEnumerable<Survey> GetAll()
            => _surveyRepository.GetAllEager();

        public Survey GetByID(long id)
            => _surveyRepository.GetEager(id);

        public void Update(Survey entity)
        {
            Validate(entity);
            _surveyRepository.Update(entity);
        }

        public void Validate(Survey entity)
        {
            //it's empty beacuse product owner requested that validation is written inside webapplication project 
        }
        //Display answers per sections
        public List<Section> GetAnswersPerDoctorSections()
        {
            List<Survey> allSurveys = _surveyRepository.GetAllEager().ToList();
            List<Section> result = new List<Section>();

            foreach (Survey survey in allSurveys)
            {    
                result.Add(survey.DoctorSection);
            }
            return result;

        }
        public List<Section> GetAnswersPerStaffSections()
        {
            List<Survey> allSurveys = _surveyRepository.GetAllEager().ToList();
            List<Section> result = new List<Section>();

            foreach (Survey survey in allSurveys)
            {
                result.Add(survey.StaffSection);
            }
            return result;

        }
        public List<Section> GetAnswersPerHygieneSections()
        {
            List<Survey> allSurveys = _surveyRepository.GetAllEager().ToList();
            List<Section> result = new List<Section>();

            foreach (Survey survey in allSurveys)
            {
                result.Add(survey.HygieneSection);
            }
            return result;

        }
        public List<Section> GetAnswersPerEquipmentSections()
        {
            List<Survey> allSurveys = _surveyRepository.GetAllEager().ToList();
            List<Section> result = new List<Section>();

            foreach (Survey survey in allSurveys)
            {
                result.Add(survey.EquipmentSection);
            }
            return result;

        }

        //Display average grade for each doctor
        public double GetAvarageGradePerDoctors(Doctor doctor)
        {
            List<Survey> allSurveys = _surveyRepository.GetAllEager().ToList();
            List<double> result = new List<double>();
            int numberOfSections = 0;

            foreach (Survey survey in allSurveys)
            {
                if (survey.Doctor.Id == doctor.GetId())
                {
                    result.Add(SumOfAnswers(survey.DoctorSection));
                    ++numberOfSections;
                }

            }
            if (numberOfSections == 0)
            {
                return 0.0;
            }
             
            return  Math.Round(SumPerSections(result)/numberOfSections,2);

        }

        //Display grades per each doctor, returns list of sections for specific doctor
        public List<Section> GetSurveysPerDoctors(Doctor doctor)
        {
            List<Survey> allSurveys = _surveyRepository.GetAllEager().ToList();
            List<Section> result = new List<Section>();

            foreach (Survey survey in allSurveys)
            {

                if (survey.Doctor.Id == doctor.GetId())
                {
                    result.Add(survey.DoctorSection);

                }
                
            }
            return result;
        }
       


        //frequency of every answer to every question in doctor section
        //returns dictionary where key is name of the answer, and list of longs is
        //list of calculated frequencies per each grade.
        public Dictionary<string, List<long>> FrequencyPerDoctorQuestions()
        {
            Dictionary<string, List<long>> result = new Dictionary<string, List<long>>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();
            List<long> answersOne = new List<long>();
            List<long> answersTwo = new List<long>();
            List<long> answersThree = new List<long>();
            List<long> answersFour = new List<long>();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section doctorSection = survey.DoctorSection;
                answersOne.Add(doctorSection.AnswerOne);
                answersTwo.Add(doctorSection.AnswerTwo);
                answersThree.Add(doctorSection.AnswerThree);
                answersFour.Add(doctorSection.AnswerFour);
            }
            result.Add(key: "AnswerOne", value: calculateFrequency(answersOne));
            result.Add(key: "AnswerTwo", value: calculateFrequency(answersTwo));
            result.Add(key: "AnswerThree", value: calculateFrequency(answersThree));
            result.Add(key: "AnswerFour", value: calculateFrequency(answersFour));

            return result;
        }
        public Dictionary<string, List<long>> FrequencyPerStaffQuestions()
        {
            Dictionary<string, List<long>> result = new Dictionary<string, List<long>>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();
            List<long> answersOne = new List<long>();
            List<long> answersTwo = new List<long>();
            List<long> answersThree = new List<long>();
            List<long> answersFour = new List<long>();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section staffSection = survey.StaffSection;
                answersOne.Add(staffSection.AnswerOne);
                answersTwo.Add(staffSection.AnswerTwo);
                answersThree.Add(staffSection.AnswerThree);
                answersFour.Add(staffSection.AnswerFour);
            }
            result.Add(key: "AnswerOne", value: calculateFrequency(answersOne));
            result.Add(key: "AnswerTwo", value: calculateFrequency(answersTwo));
            result.Add(key: "AnswerThree", value: calculateFrequency(answersThree));
            result.Add(key: "AnswerFour", value: calculateFrequency(answersFour));

            return result;
        }

        public Dictionary<string, List<long>> FrequencyPerHygieneQuestions()
        {
            Dictionary<string, List<long>> result = new Dictionary<string, List<long>>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();
            List<long> answersOne = new List<long>();
            List<long> answersTwo = new List<long>();
            List<long> answersThree = new List<long>();
            List<long> answersFour = new List<long>();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section hygieneSection = survey.HygieneSection;
                answersOne.Add(hygieneSection.AnswerOne);
                answersTwo.Add(hygieneSection.AnswerTwo);
                answersThree.Add(hygieneSection.AnswerThree);
                answersFour.Add(hygieneSection.AnswerFour);
            }
            result.Add(key: "AnswerOne", value: calculateFrequency(answersOne));
            result.Add(key: "AnswerTwo", value: calculateFrequency(answersTwo));
            result.Add(key: "AnswerThree", value: calculateFrequency(answersThree));
            result.Add(key: "AnswerFour", value: calculateFrequency(answersFour));

            return result;
        }

        public Dictionary<string, List<long>> FrequencyPerEquipmentQuestions()
        {
            Dictionary<string, List<long>> result = new Dictionary<string, List<long>>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();
            List<long> answersOne = new List<long>();
            List<long> answersTwo = new List<long>();
            List<long> answersThree = new List<long>();
            List<long> answersFour = new List<long>();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section equipmentSection = survey.EquipmentSection;
                answersOne.Add(equipmentSection.AnswerOne);
                answersTwo.Add(equipmentSection.AnswerTwo);
                answersThree.Add(equipmentSection.AnswerThree);
                answersFour.Add(equipmentSection.AnswerFour);
            }
            result.Add(key: "AnswerOne", value: calculateFrequency(answersOne));
            result.Add(key: "AnswerTwo", value: calculateFrequency(answersTwo));
            result.Add(key: "AnswerThree", value: calculateFrequency(answersThree));
            result.Add(key: "AnswerFour", value: calculateFrequency(answersFour));

            return result;
        }

        public List<long> calculateFrequency(List<long> answers)
        {
            List<long> result = new List<long>();
            long a1=0;
            long a2=0;
            long a3=0;
            long a4=0;
            long a5=0;

            foreach(long answer in answers)
            {
                if (answer == 1)
                {
                    ++a1;
                }else if(answer==2)
                {
                    ++a2;
                }else if(answer==3)
                {
                    ++a3;
                }else if (answer == 4)
                {
                    ++a4;
                }else if(answer == 5)
                {
                    ++a5;
                }
            }
            result.Add(a1);
            result.Add(a2);
            result.Add(a3);
            result.Add(a4);
            result.Add(a5);

            return result;
        }

        //returns list of mean values per questions in doctors section
        public List<double> MeanValuesPerDoctorQuestions()
        {
            
            List<double> means = new List<double>();
            List<double> answersOne = new List<double>();
            List<double> answersTwo = new List<double>();
            List<double> answersThree = new List<double>();
            List<double> answersFour = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return means;
            }
            foreach (Survey survey in surveys)
            {
                Section doctorSection = survey.DoctorSection;
                answersOne.Add(doctorSection.AnswerOne);
                answersTwo.Add(doctorSection.AnswerTwo);
                answersThree.Add(doctorSection.AnswerThree);
                answersFour.Add(doctorSection.AnswerFour);
            }
            means.Add(Math.Round(SumOfQuestions(answersOne) / surveys.Count,2));
            means.Add(Math.Round(SumOfQuestions(answersTwo) / surveys.Count,2));
            means.Add(Math.Round(SumOfQuestions(answersThree) / surveys.Count,2));
            means.Add(Math.Round(SumOfQuestions(answersFour) / surveys.Count,2));

            return means;

        }
        public List<double> MeanValuesPerStaffQuestions()
        {
            List<double> result = new List<double>();
            List<double> answersOne = new List<double>();
            List<double> answersTwo = new List<double>();
            List<double> answersThree = new List<double>();
            List<double> answersFour = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section staffSection = survey.StaffSection;
                answersOne.Add(staffSection.AnswerOne);
                answersTwo.Add(staffSection.AnswerTwo);
                answersThree.Add(staffSection.AnswerThree);
                answersFour.Add(staffSection.AnswerFour);
            }
            result.Add(Math.Round(SumOfQuestions(answersOne) / surveys.Count, 2));
            result.Add(Math.Round(SumOfQuestions(answersTwo) / surveys.Count, 2));
            result.Add(Math.Round(SumOfQuestions(answersThree) / surveys.Count, 2));
            result.Add(Math.Round(SumOfQuestions(answersFour) / surveys.Count, 2));
           

            return result;

        }
        public List<double> MeanValuesPerHygieneQuestions()
        {
            List<double> result = new List<double>();
            List<double> answersOne = new List<double>();
            List<double> answersTwo = new List<double>();
            List<double> answersThree = new List<double>();
            List<double> answersFour = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section hygieneSection = survey.HygieneSection;
                answersOne.Add(hygieneSection.AnswerOne);
                answersTwo.Add(hygieneSection.AnswerTwo);
                answersThree.Add(hygieneSection.AnswerThree);
                answersFour.Add(hygieneSection.AnswerFour);
            }
            result.Add(Math.Round(SumOfQuestions(answersOne) / surveys.Count, 2));
            result.Add(Math.Round(SumOfQuestions(answersTwo) / surveys.Count, 2));
            result.Add(Math.Round(SumOfQuestions(answersThree) / surveys.Count, 2));
            result.Add(Math.Round(SumOfQuestions(answersFour) / surveys.Count, 2));
            return result;

        }

        public List<double> MeanValuesPerEquipmentQuestions()
        {
            List<double> result = new List<double>();
            List<double> answersOne = new List<double>();
            List<double> answersTwo = new List<double>();
            List<double> answersThree = new List<double>();
            List<double> answersFour = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section equipmentSection = survey.EquipmentSection;
                answersOne.Add(equipmentSection.AnswerOne);
                answersTwo.Add(equipmentSection.AnswerTwo);
                answersThree.Add(equipmentSection.AnswerThree);
                answersFour.Add(equipmentSection.AnswerFour);
            }
            result.Add(Math.Round(SumOfQuestions(answersOne) / surveys.Count, 2));
            result.Add(Math.Round(SumOfQuestions(answersTwo) / surveys.Count, 2));
            result.Add(Math.Round(SumOfQuestions(answersThree) / surveys.Count, 2));
            result.Add(Math.Round(SumOfQuestions(answersFour) / surveys.Count, 2));

            return result;

        }
        public double SumOfQuestions(List<double> means) 
        {
            double result=0.0;
            foreach( double question in means)
            {
                result += question;
            }
            return result;
        }
        public double MeanValuesPerDoctorSection()
        {
            List<double> means = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return 0.0;
            }
            foreach (Survey survey in surveys)
            {
                Section doctorSection = survey.DoctorSection;
                means.Add(SumOfAnswers(doctorSection));
              
            }
            return Math.Round(SumPerSections(means)/surveys.Count,2);
        }

        public double MeanValuesPerStaffSection()
        {
            List<double> means = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return 0.0;
            }
            foreach (Survey survey in surveys)
            {
                Section staffSection = survey.StaffSection;
                means.Add(SumOfAnswers(staffSection));

            }
            return Math.Round(SumPerSections(means) / surveys.Count, 2);
        }
        public double MeanValuesPerEquipmentSection()
        {
            List<double> means = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return 0.0;
            }
            foreach (Survey survey in surveys)
            {
                Section equipmentSection = survey.EquipmentSection;
                means.Add(SumOfAnswers(equipmentSection));

            }
            return Math.Round(SumPerSections(means) / surveys.Count, 2);
        }
        public double MeanValuesPerHygieneSection()
        {
            List<double> means = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return 0.0;
            }
            foreach (Survey survey in surveys)
            {
                Section hygieneSection = survey.HygieneSection;
                means.Add(SumOfAnswers(hygieneSection));

            }
            return Math.Round(SumPerSections(means) / surveys.Count, 2);
        }

        public double SumOfAnswers(Section section)
        {
            return (double)(section.AnswerOne + section.AnswerTwo + section.AnswerThree + section.AnswerFour )/4;
        }
        public double SumPerSections(List<double> sums)
        {
            double result = 0.0;    
            
            foreach (double sum in sums)
            {
                result += sum;

            }
            return result;
        }
    }
}
