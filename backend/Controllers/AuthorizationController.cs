using backend.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IAuthorizationService = backend.Services.Authorization.IAuthorizationService;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        // GET: api/authorization
        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                return await _authorizationService.GetUserAuthorize(userId);
            }
            else
            {
                return BadRequest("Invalid user ID");
            }
        }

        // GET: api/authorization/5
        [Authorize]
        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            return await _authorizationService.GetUserById(id);
        }

        // POST: api/authorization
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            return await _authorizationService.LoginUser(loginDTO);
        }

        // POST: api/Authorization
        [HttpPost("signup")]
        public async Task<ActionResult<UserDTO>> PostRegisterUser(SignupDTO signupDTO)
        {
            return await _authorizationService.SignupUser(signupDTO);
        }
    }
}
