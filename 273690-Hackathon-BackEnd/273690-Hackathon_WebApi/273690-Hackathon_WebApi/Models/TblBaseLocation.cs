using System;
using System.Collections.Generic;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class TblBaseLocation
    {
        public TblBaseLocation()
        {
            TblNotParticipated = new HashSet<TblNotParticipated>();
        }

        public int BaseLocationId { get; set; }
        public string BaseLocation { get; set; }

        public virtual ICollection<TblNotParticipated> TblNotParticipated { get; set; }
    }
}
