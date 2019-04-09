using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblIiepcategory
    {
        public TblIiepcategory()
        {
            TblEventEnrollmentDetails = new HashSet<TblEventEnrollmentDetails>();
        }

        public int IiepcategoryId { get; set; }
        public string Iiepcategory { get; set; }

        public virtual ICollection<TblEventEnrollmentDetails> TblEventEnrollmentDetails { get; set; }
    }
}
