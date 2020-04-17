using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ImdbApi.Controllers
{
    public class HomeController : Controller
    {
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return Authenticate();
        //}

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login()
        {
            string user = Request.Form["username"];
            string pass = Request.Form["password"];
            if (user.Equals("Admin") && pass.Equals("preet"))
            {
                return Authenticate();
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }

        public IActionResult Authenticate()
        {
            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "user_ID")
            };
            var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Audience,
                Claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { access_token = tokenJson });
        }
    }
}