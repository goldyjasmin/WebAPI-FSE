using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.BAL.Domain
{
    public class UserDetails
    {
        public List<User> user { get; set; }
        public List<RoleDetails> Roles { get; set; }
    }
    public class User
    {
        public string UserId { get; set; }
        public int SelectedRoleId { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
       
    }
    public class RoleDetails
    {
        public int RoleId { get; set; }
        public string RolenNme { get; set; }
    }

  

}
