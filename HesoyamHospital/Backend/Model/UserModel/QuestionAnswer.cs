using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class QuestionAnswer : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private Question _question;
        public Question Question { get => _question; set { _question = value; _questionId = value.Id; } }

        private long _questionId;
        public long QuestionId { get => _questionId; set => _questionId = value; }

        private Rating _rating;
        public Rating Rating { get => _rating; set { _rating = value; _ratingId = value.Id; } }

        private long _ratingId;
        public long RatingId { get => _ratingId; set => _ratingId = value; }

        public QuestionAnswer() { }
        public QuestionAnswer(Question question, Rating rating)
        {
            _question = question;
            _questionId = question.Id;
            _rating = rating;
            _ratingId = rating.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            QuestionAnswer qa = obj as QuestionAnswer;
            return _id == qa._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;
    }
}
