﻿using System;
using System.Collections.Generic;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class TblRating
    {
        public TblRating()
        {
            TblFeedbackDetails = new HashSet<TblFeedbackDetails>();
        }

        public int RatingId { get; set; }
        public string RatingDesc { get; set; }

        public virtual ICollection<TblFeedbackDetails> TblFeedbackDetails { get; set; }
    }
}
