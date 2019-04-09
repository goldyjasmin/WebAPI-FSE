using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblBusinessUnit
    {
        public TblBusinessUnit()
        {
            TblEventEnrollmentDetails = new HashSet<TblEventEnrollmentDetails>();
        }

        public int BusinessUnitId { get; set; }
        public string BusinessUnit { get; set; }

        public virtual ICollection<TblEventEnrollmentDetails> TblEventEnrollmentDetails { get; set; }
    }
}
