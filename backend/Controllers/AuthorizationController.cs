using backend.Models;
using backend.ModelsDTO;
using backend.Services.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly PasswordHash _passwordHash;

        public AuthorizationController(DatabaseContext context, IConfiguration configuration, PasswordHash passwordHash)
        {
            _context = context;
            _configuration = configuration;
            _passwordHash = passwordHash;
        }

        // POST: api/authorization
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> LoginUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }

            var user = await _context.User.FirstOrDefaultAsync(u => u.Nickname == userDTO.Nickname);

            if (user == null)
            {
                return Unauthorized("User do not exist");
            }

            if (!_passwordHash.VerifyPassword(userDTO.Password, user.Password, Convert.FromBase64String(user.PasswordSalt)))
            {
                return Unauthorized("Password is wrong");
            }

            return Ok(GenerateJWT(userDTO));
        }

        // POST: api/Authorization
        [HttpPost("signup")]
        public async Task<ActionResult<UserDTO>> PostRegisterUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }

            var checkIfNicknameExist = await _context.User.Where(u => u.Nickname == userDTO.Nickname).ToListAsync();

            if (checkIfNicknameExist.Any())
            {
                return BadRequest("Nickname exist");
            }

            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string userPasswordSalt = Convert.ToBase64String(salt);
            string userPasswordHash = _passwordHash.CreatePasswordHash(userDTO.Password, salt);

            _context.User.Add(new User()
            {
                Nickname = userDTO.Nickname,
                Password = userPasswordHash,
                PasswordSalt = userPasswordSalt
            });
            await _context.SaveChangesAsync();

            return Ok("Registration successful");
        }

        private string GenerateJWT(UserDTO userDTO)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userDTO.Nickname),
            };

            var token = new JwtSecurityToken(null, null,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
