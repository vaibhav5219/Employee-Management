using Microsoft.AspNetCore.Mvc;
using EF_Core.Models;
using EE_Management.ModelView;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EE_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly VaibhavTestDbContext _dbContext;
        public AuthController(IConfiguration configuration)
        {
            _dbContext = new VaibhavTestDbContext();
            _configuration = configuration;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] UserModel userModel)
        {
            using (var db = _dbContext)
            {
                if (userModel != null)
                {
                    var resultLoginCheck = db.AspNetUsers
                        .Where(e => e.Email == userModel.UserName)
                        .FirstOrDefault();
                    if (resultLoginCheck == null)
                    {
                        return BadRequest("Invalid Credentials");
                    }
                    else
                    {
                        userModel.UserMessage = "Login Success";
                        userModel.AccessToken = GetToken(userModel);
                        return Ok(userModel);
                    }
                }
                else
                {
                    return BadRequest("No Data Posted");
                }
            }
        }

        public string GetToken(UserModel userData)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", userData.UserId.ToString()),
                new Claim("DisplayName", userData.UserName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires:DateTime.UtcNow.AddMinutes(10),
                signingCredentials:signIn);
            
            var Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;
        }
        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
