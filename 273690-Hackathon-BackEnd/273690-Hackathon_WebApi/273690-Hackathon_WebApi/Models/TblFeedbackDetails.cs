using System;
using System.Collections.Generic;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class TblFeedbackDetails
    {
        public int FeedbackDetailsId { get; set; }
        public string EventId { get; set; }
        public int EmployeeId { get; set; }
        public int? RatingId { get; set; }
        public int? QuestionId { get; set; }
        public string Answer { get; set; }
        public int? UserCategoryId { get; set; }
        public int? FeedbackOptionId { get; set; }

        public virtual TblFeedbackOptions FeedbackOption { get; set; }
        public virtual TblFeedbackQuestions Question { get; set; }
        public virtual TblRating Rating { get; set; }
        public virtual TblUserCategory UserCategory { get; set; }
    }
}
