using Azure;
using backend.Models;
using backend.ModelsDTO;
using backend.Services.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using IAuthorizationService = backend.Services.Authorization.IAuthorizationService;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(DatabaseContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            _authorizationService = authorizationService;
        }

        // GET: api/authorization
        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                var patient = await _context.User.FindAsync(userId);

                if (patient == null)
                {
                    return NotFound();
                }

                return new UserDTO()
                {
                    Nickname = patient.Nickname
                };
            }
            else
            {
                return BadRequest("Invalid user ID");
            }
        }

        // GET: api/authorization/5
        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var patient = await _context.User.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return new UserDTO()
            {
                Nickname = patient.Nickname
            };
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

            if (!_authorizationService.VerifyPassword(userDTO.Password, user.Password, Convert.FromBase64String(user.PasswordSalt)))
            {
                return Unauthorized("Password is wrong");
            }

            return Ok(_authorizationService.GenerateJWT(user));
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
            string userPasswordHash = _authorizationService.CreatePasswordHash(userDTO.Password, salt);

            _context.User.Add(new User()
            {
                Nickname = userDTO.Nickname,
                Password = userPasswordHash,
                PasswordSalt = userPasswordSalt
            });
            await _context.SaveChangesAsync();

            return Ok("Registration successful");
        }

        /*// POST: api/Authorization
        [HttpPost("change-password")]
        public async Task<ActionResult<UserDTO>> ChangeUserPassword(HttpRequestMessage requestMessage)
        {
            return Ok("zmienles haslo");
        }*/
    }
}
