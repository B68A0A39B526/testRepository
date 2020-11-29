// File:    FeedbackService.cs
// Author:  nikola
// Created: 6. maj 2020 18:46:57
// Purpose: Definition of Class FeedbackService

using System.Collections.Generic;
using System.Linq;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.MiscRepository;
using Backend.Repository.MySQLRepository.UsersRepository;

namespace Backend.Service.MiscService
{
    public class FeedbackService : IService<Feedback, long>
    {
        private readonly FeedbackRepository _feedbackRepository;
        private readonly QuestionRepository _questionRepository;

        public FeedbackService(FeedbackRepository feedbackRepository, QuestionRepository questionRepository)
        {
            _feedbackRepository = feedbackRepository;
            _questionRepository = questionRepository;
        }

        public Feedback Create(Feedback entity)
        {
            Validate(entity);

            return _feedbackRepository.Create(entity);
        }

        public void Delete(Feedback entity)
            => _feedbackRepository.Delete(entity);

        public IEnumerable<Question> GetQuestions()
            => _questionRepository.GetAll();

        public Feedback GetByUser(User user)
            => _feedbackRepository.GetAllEager().FirstOrDefault(f => f.User.Equals(user));

        public IEnumerable<Feedback> GetAll()
            => _feedbackRepository.GetAllEager();

        public Feedback GetByID(long id)
            => _feedbackRepository.GetEager(id);

        public void Update(Feedback entity)
        {
            Validate(entity);
            _feedbackRepository.Update(entity);
        }

        public void Publish(long id)
        {
            Feedback feedback = _feedbackRepository.GetEager(id);
            if (feedback == null) return;
            
            feedback.Published = true;
            _feedbackRepository.Update(feedback);
        }

        public List<Feedback> GetAllUnpublished()
        {
            List<Feedback> result = new List<Feedback>();
            List<Feedback> feedbacks = _feedbackRepository.GetAllEager().ToList();

            foreach (Feedback feedback in feedbacks)
            {
                if (!feedback.Published)
                {
                    result.Add(feedback);
                }
            }

            return result;
        }

        public List<Feedback> GetAllPublished()
        {
            List<Feedback> result = new List<Feedback>();
            List<Feedback> feedbacks = _feedbackRepository.GetAllEager().ToList();

            foreach (Feedback feedback in feedbacks)
            {
                if (feedback.Published)
                {
                    result.Add(feedback);
                }
            }

            return result;
        }

        public void Validate(Feedback entity)
        {
        }
    }
}