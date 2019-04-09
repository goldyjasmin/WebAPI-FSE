using System;
using System.Collections.Generic;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class TblFeedbackOptions
    {
        public TblFeedbackOptions()
        {
            TblFeedbackDetails = new HashSet<TblFeedbackDetails>();
        }

        public int FeedbackOptionId { get; set; }
        public string FeedbackDesc { get; set; }

        public virtual ICollection<TblFeedbackDetails> TblFeedbackDetails { get; set; }
    }
}
