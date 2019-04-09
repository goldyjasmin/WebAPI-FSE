using System;
using System.Collections.Generic;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class TblBusinessUnit
    {
        public TblBusinessUnit()
        {
            TblNotParticipated = new HashSet<TblNotParticipated>();
        }

        public int BusinessUnitId { get; set; }
        public string BusinessUnit { get; set; }

        public virtual ICollection<TblNotParticipated> TblNotParticipated { get; set; }
    }
}
