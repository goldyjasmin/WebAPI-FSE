using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblLogin
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public bool IsActive { get; set; }

        public virtual TblRoleType Role { get; set; }
    }
}
