using FSE.BAL.Domain;
using FSE.DAL.Models;
using System.Linq;

namespace FSE.BAL
{
    public interface IAuthorizationRepo
    {
       Login ValidateUser(string username, string password);
       
    }
    public class AuthorizationRepo : IAuthorizationRepo
    {
        private readonly FeedBackManagementSystemContext _context;
        public AuthorizationRepo(FeedBackManagementSystemContext context)
        {
            _context = context;
        }
        public Login  ValidateUser(string username, string password)
        {
            Login result = new Login();
            var user =  _context.TblLogin.FirstOrDefault(x => x.UserId == username && x.Password == password);
            if (user != null)
            {
                string role = string.Empty;
                if (user.RoleId == 1)
                {
                    role = "Admin";
                }
                else if (user.RoleId == 2)
                {
                    role = "POC";
                }
                else
                {
                    role = "EventPoc";
                }
                result.RoleId = user.RoleId;
                result.RoleName = role;
                result.Id = user.Id;
            }
            return result;

        }

    }
}
