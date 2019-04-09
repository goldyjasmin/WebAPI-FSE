using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblFeedbackQuestions
    {
        public TblFeedbackQuestions()
        {
            TblFeedbackDetailsQuestionId1Navigation = new HashSet<TblFeedbackDetails>();
            TblFeedbackDetailsQuestionId2Navigation = new HashSet<TblFeedbackDetails>();
        }

        public int QuestionId { get; set; }
        public string QuestionName { get; set; }

        public virtual ICollection<TblFeedbackDetails> TblFeedbackDetailsQuestionId1Navigation { get; set; }
        public virtual ICollection<TblFeedbackDetails> TblFeedbackDetailsQuestionId2Navigation { get; set; }
    }
}
