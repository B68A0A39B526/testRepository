using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class Question : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public Question(long id, string text)
        {
            Id = id;
            Text = text;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Question q = obj as Question;
            return Id == q.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        
    }
}
