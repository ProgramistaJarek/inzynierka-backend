﻿using backend.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IAuthorizationService = backend.Services.Authorization.IAuthorizationService;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Get user by token
        /// </summary>
        [Authorize]
        [HttpGet(Name = "getUserAuthorize")]
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

        /// <summary>
        /// Get user by id
        /// </summary>
        [Authorize]
        [HttpGet("user/{id}", Name = "getUserById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            return await _authorizationService.GetUserById(id);
        }

        /// <summary>
        /// Login user
        /// </summary>
        [HttpPost("login", Name = "login")]
        public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
        {
            return await _authorizationService.LoginUser(loginDTO);
        }

        /// <summary>
        /// Signup user
        /// </summary>
        [HttpPost("signup", Name = "signup")]
        public async Task<ActionResult<string>> PostRegisterUser(SignupDTO signupDTO)
        {
            return await _authorizationService.SignupUser(signupDTO);
        }
    }
}
