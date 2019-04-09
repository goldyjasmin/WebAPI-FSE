using System;
using System.Collections.Generic;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class TblLogin
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual TblRoleType Role { get; set; }
    }
}
