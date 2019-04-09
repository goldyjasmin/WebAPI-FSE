using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblRoleType
    {
        public TblRoleType()
        {
            TblLogin = new HashSet<TblLogin>();
        }

        public int RoleTypeId { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<TblLogin> TblLogin { get; set; }
    }
}
