using System;
using System.Collections.Generic;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class TblFeedbackQuestions
    {
        public TblFeedbackQuestions()
        {
            TblFeedbackDetails = new HashSet<TblFeedbackDetails>();
        }

        public int QuestionId { get; set; }
        public string QuestionName { get; set; }

        public virtual ICollection<TblFeedbackDetails> TblFeedbackDetails { get; set; }
    }
}
