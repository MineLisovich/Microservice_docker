using Authorization.Microservice.Domain.Entities;
using Authorization.Microservice.Domain.Repositories;
using Authorization.Microservice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using Authorization.Microservice.Models;

namespace Authorization.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public AuthController(IUsersRepository usersRepository) { _usersRepository = usersRepository; }

        [HttpGet]
        [Route("getuser")]
        public IEnumerable<Users> GetUsers()
        {
            IEnumerable<Users> users = _usersRepository.GetUsersList();
            return users;
        }
        [HttpPost]
        [Route("authorization")]
        public IResult GetUserLoginPass([FromBody]LoginModel model)   
        {
            var identity = GetIdentity(model.Login, model.Password);
            if (identity == null)
            {
                return Results.NotFound(new { message = "Invalid username or password" });
            }

            var date_time = DateTime.UtcNow;
           
            // Создаём JWT token
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: date_time,
                claims: identity.Claims,
                expires: date_time.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

  

            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", encodedJwt,
              new CookieOptions
              {
                  MaxAge = TimeSpan.FromMinutes(60)
              });

            return Results.Json(encodedJwt);

        }
        private ClaimsIdentity GetIdentity(string login, string password)
        {
            Users user = _usersRepository.FindByLoginPassword(login, password);
            if (user != null)
            {
                // определяем какие данные будут храниться в jwt токене
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity = 
                    new ClaimsIdentity(claims,"Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
          
          return null;     
        }
    }
}
