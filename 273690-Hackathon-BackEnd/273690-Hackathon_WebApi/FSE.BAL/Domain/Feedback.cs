using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.BAL.Domain
{
    public class Feedback
    {
        public int EmployeeId { get; set; }
        public string EventId { get; set; }

        public int? RatingId { get; set; }
        public int? QuestionId { get; set; }
        public string Qstn1Ans { get; set; }
        public string Qstn2Ans { get; set; }
        public int? UserCategoryId { get; set; }
        public int? FeedbackOptionId { get; set; }

        public bool IsAuthorized { get; set; }

        public string EventName { get; set; }
        public string EventBenificary { get; set; }

        public int LivesImpacted { get; set; }
    }

    

}
