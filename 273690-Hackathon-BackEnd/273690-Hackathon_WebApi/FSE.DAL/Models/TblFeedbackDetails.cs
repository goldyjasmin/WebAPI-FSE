using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblFeedbackDetails
    {
        public int FeedbackDetailsId { get; set; }
        public string EventId { get; set; }
        public int EmployeeId { get; set; }
        public int? RatingId { get; set; }
        public int? QuestionId1 { get; set; }
        public string Answer1 { get; set; }
        public int? QuestionId2 { get; set; }
        public string Answer2 { get; set; }
        public int? UserCategoryId { get; set; }
        public int? FeedbackOptionId { get; set; }

        public virtual TblFeedbackOptions FeedbackOption { get; set; }
        public virtual TblFeedbackQuestions QuestionId1Navigation { get; set; }
        public virtual TblFeedbackQuestions QuestionId2Navigation { get; set; }
        public virtual TblRating Rating { get; set; }
        public virtual TblUserCategory UserCategory { get; set; }
    }
}
