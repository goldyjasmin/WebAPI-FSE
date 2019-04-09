using FSE.BAL;
using FSE.BAL.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _273690_Hackathon_WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
       

        private readonly AuthorizationRepo _repo;

        public AuthorizationController(AuthorizationRepo repo)
        {
           _repo = repo;
        }

        [HttpGet, Route("validate")]
        public async Task<ActionResult<Login>> validate(string username, string password)
        {

             var mytask= Task.Run(() => _repo.ValidateUser(username, password));
            var user = await mytask;
          
            if (user != null && user.Id>0)
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
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, role)
                    };
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:4545",
                    audience: "http://localhost:4545",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new {
                    role = user.RoleName,
                    Token = tokenString });
            }

            else
            {
                return Unauthorized();
            }
        }
    }
}