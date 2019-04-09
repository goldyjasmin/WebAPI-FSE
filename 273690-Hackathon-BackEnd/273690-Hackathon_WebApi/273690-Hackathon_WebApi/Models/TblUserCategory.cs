using System;
using System.Collections.Generic;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class TblUserCategory
    {
        public TblUserCategory()
        {
            TblFeedbackDetails = new HashSet<TblFeedbackDetails>();
            TblNotParticipated = new HashSet<TblNotParticipated>();
        }

        public int UserCategoryId { get; set; }
        public string UserCategoryName { get; set; }

        public virtual ICollection<TblFeedbackDetails> TblFeedbackDetails { get; set; }
        public virtual ICollection<TblNotParticipated> TblNotParticipated { get; set; }
    }
}
