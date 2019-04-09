using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
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
