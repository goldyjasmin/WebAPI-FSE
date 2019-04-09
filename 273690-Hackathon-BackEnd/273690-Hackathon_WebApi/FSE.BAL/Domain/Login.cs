using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.BAL.Domain
{
    public class Login
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
