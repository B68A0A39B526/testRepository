using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class QuestionAnswer : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Question Question { get; set; }
        public virtual Rating Rating { get; set; }

        public QuestionAnswer() { }
        public QuestionAnswer(Question question, Rating rating)
        {
            Question = question;
            Rating = rating;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            QuestionAnswer qa = obj as QuestionAnswer;
            return Id == qa.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
