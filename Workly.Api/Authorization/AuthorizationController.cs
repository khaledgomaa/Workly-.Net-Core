using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Workly.Domain;
using Workly.Domain.ViewModels;

namespace Workly.Api.Authorization
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly string _secret;
        private readonly UserManager<ApplicationUser> userManager;

        public AuthorizationController(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            this.userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> GenerateToken(LoginModel model)
        {
            if (!ModelState.IsValid)
                return Unauthorized();

            LoginModel checkUserFoundInDb = await Authenticate(model);
            if (checkUserFoundInDb == null)
                return Unauthorized();

            byte[] key = Convert.FromBase64String(_secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, model.UserName)}),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return Ok(handler.WriteToken(token));
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

        public ClaimsPrincipal GetClaims(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(_secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }

        public string ValidateToken(string token)
        {
            string username = null;
            ClaimsPrincipal principal = GetClaims(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim.Value;
            return username;
        }
    }
}
