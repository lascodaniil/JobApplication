using JobSolution.Domain;
using JobSolution.Domain.Auth;
using JobSolution.Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Infrastructure.WebAuth
{
    public class JwtTokenProvider
    {
        private readonly RequestDelegate _next;
        private DateTime TokenExpiration;
        private SigningCredentials SigningCredentials;
        private JobDbContext jobDbContext;
        private UserManager<User> UserManager;
        private SignInManager<User> SignInManager;



        public static readonly string PrivateKey = "JobClientAPIKey_JobClientAPIKey";
        public static readonly SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(PrivateKey));
        public static readonly string Issuer = "JobSolution.WebService";
        public static string TokenEndPoint = "/api/connect/token"; 

        public JwtTokenProvider(RequestDelegate next, JobDbContext dbContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _next = next;
            TokenExpiration = DateTime.Now.AddDays(30);
            SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            jobDbContext = dbContext;
            UserManager = userManager;
            SignInManager = signInManager;

        }

        public Task Invoke(HttpContext httpContext)
        {
            if (!httpContext.Request.Path.Value.Equals(TokenEndPoint, StringComparison.Ordinal))
            {
                _next(httpContext);
            }


            if (httpContext.Request.Method.Equals("POST") && httpContext.Request.HasFormContentType)
            {

                return CreateToken(httpContext);
            }
            else
            {

                httpContext.Response.StatusCode = 400;
                return httpContext.Response.WriteAsync("Bad request.");
            }
        }

        private async Task CreateToken(HttpContext httpContext)
        {
            try
            {
                string username = httpContext.Request.Form["username"];
                string password = httpContext.Request.Form["password"];


                var user = await UserManager.FindByNameAsync(username);
                if (user == null && username.Contains("@")) user = await UserManager.FindByEmailAsync(username);

                var success = false;
                if (user != null && string.IsNullOrEmpty(user?.PasswordHash))
                {
                    success = true;
                }
                else
                {
                   success = user != null && await UserManager.CheckPasswordAsync(user, password);
                }
                if (success)
                {
                    DateTime now = DateTime.UtcNow;
                    var claims = new[] {
                         new Claim(JwtRegisteredClaimNames.Iss, Issuer),
                         new Claim(JwtRegisteredClaimNames.Sub, username),
                         new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString()),
                         new Claim(JwtRegisteredClaimNames.Iat, new
                        DateTimeOffset(now).ToUnixTimeSeconds().ToString(),
                        ClaimValueTypes.Integer64)};
                    var token = new JwtSecurityToken(
                         claims: claims,
                         notBefore: now,
                         expires: DateTime.Now.AddDays(30),
                         signingCredentials: SigningCredentials);
                    var encodedToken = new
                   JwtSecurityTokenHandler().WriteToken(token);

                    var jwt = new
                    {
                        access_token = encodedToken
                    };

                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(jwt));
                    return;
                }
            }
            catch (Exception ex)
            {
            }
            httpContext.Response.StatusCode = 400;
            await httpContext.Response.WriteAsync("Invalid username or password.");
        }
    }
}
