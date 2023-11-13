using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCore_Api_1.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetCore_Api_1.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UserController: ControllerBase
    {
        public IConfiguration _configuration;
        public UserController(IConfiguration configuration) {
            _configuration= configuration;
        }
        [HttpPost]
        [Route("login")]
        public dynamic login([FromBody] Object opData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(opData.ToString());
            string name = data.name.ToString();
            string password = data.password.ToString();

            UserModel userToLogin = UserModel.DB().Where(x => x.Name == name && x.password == password).FirstOrDefault();

            if (userToLogin == null)
            {
                return new
                {
                    success=false,
                    message= "Invalid credentials",
                    result=""
                };
            }

            
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
           

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
           {
                new Claim("id", userToLogin.ID),
                new Claim(ClaimTypes.Name, userToLogin.Name),
                new Claim(ClaimTypes.Email, userToLogin.Email),
                new Claim(ClaimTypes.Role, userToLogin.Rol),
            };

            var token = new JwtSecurityToken(
               _configuration["Jwt:Issuer"],
               _configuration["Jwt:Audience"],
               claims,
               expires: DateTime.Now.AddMinutes(60),
               signingCredentials: credentials
                );


            return new
            {
                success = true,
                message = "Exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
