using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblBaseLocation
    {
        public TblBaseLocation()
        {
            TblEventEnrollmentDetails = new HashSet<TblEventEnrollmentDetails>();
            TblNotParticipated = new HashSet<TblNotParticipated>();
            TblPoceventDetails = new HashSet<TblPoceventDetails>();
        }

        public int BaseLocationId { get; set; }
        public string BaseLocation { get; set; }

        public virtual ICollection<TblEventEnrollmentDetails> TblEventEnrollmentDetails { get; set; }
        public virtual ICollection<TblNotParticipated> TblNotParticipated { get; set; }
        public virtual ICollection<TblPoceventDetails> TblPoceventDetails { get; set; }
    }
}
