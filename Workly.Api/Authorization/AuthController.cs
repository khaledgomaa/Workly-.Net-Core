using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Workly.Domain;
using Workly.Domain.ViewModels;

namespace Workly.Api.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        string secretKey = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        private readonly UserManager<ApplicationUser> userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(LoginModel model)
        {
            if (!ModelState.IsValid)
                return Unauthorized();

            LoginModel checkUserFoundInDb = await Authenticate(model);
            if (checkUserFoundInDb == null)
                return Unauthorized();

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    issuer: "workly.api",
                    audience: "allRoles",
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signInCredentials
                );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        private async Task<LoginModel> Authenticate(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return null;
            bool checkPassword = await userManager.CheckPasswordAsync(user, model.Password);
            if (checkPassword)
                return model;
            return null;
        }
    }
}
