using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.FeedbackFeature
{
    public class NewFeedbackDTO
    {
        public string Comment { get; set; }

        public bool Anonymous { get; set; }

        public bool Public { get; set; }

        public NewFeedbackDTO() { }

        public NewFeedbackDTO(string _comment, bool _anonymous, bool _public)
        {
            this.Comment = _comment;
            this.Anonymous = _anonymous;
            this.Public = _public;
        }
    }
}
