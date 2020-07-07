
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Workly.Domain.ViewModels;

namespace Workly.Authorization
{
    public class JwtManager
    {
        private readonly string Secret = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        [AllowAnonymous]
        public IActionResult GenerateToken(LoginModel model)
        {
            LoginModel checkUserFoundInDb = Authenticate(model);
            if (checkUserFoundInDb == null)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            byte[] key = Convert.FromBase64String(Secret);
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
    }
}
