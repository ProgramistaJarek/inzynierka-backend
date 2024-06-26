﻿using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace backend.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthorizationService(IAuthorizationRepository authorizationRepository, IConfiguration configuration, IMapper mapper)
        {
            _authorizationRepository = authorizationRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        private string CreatePasswordHash(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)
            );

            return hashed;
        }

        private bool VerifyPassword(string enterPassword, string storedHash, byte[] storedSalt)
        {
            string hashToCompare = CreatePasswordHash(enterPassword, storedSalt);
            return hashToCompare == storedHash;
        }

        private string GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nickname),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var token = new JwtSecurityToken(null, null,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ActionResult<string>> LoginUser(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return new BadRequestResult();
            }

            var user = await _authorizationRepository.GetUserByNickname(loginDTO.Username);

            if (user == null)
            {
                return new UnauthorizedObjectResult("User do not exist");
            }

            if (!VerifyPassword(loginDTO.Password, user.Password, Convert.FromBase64String(user.PasswordSalt)))
            {
                return new UnauthorizedObjectResult("Password is wrong");
            }

            return new OkObjectResult(GenerateJWT(user));
        }

        public async Task<ActionResult<string>> SignupUser(SignupDTO signupDTO)
        {
            if (signupDTO == null)
            {
                return new BadRequestResult();
            }

            var checkIfNicknameExist = await _authorizationRepository.GetUserByNickname(signupDTO.Nickname);

            if (checkIfNicknameExist != null)
            {
                return new BadRequestObjectResult("Username exist");
            }

            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string userPasswordSalt = Convert.ToBase64String(salt);
            string userPasswordHash = CreatePasswordHash(signupDTO.Password, salt);


            var newUser = _mapper.Map<User>(signupDTO);

            newUser.Password = userPasswordHash;
            newUser.PasswordSalt = userPasswordSalt;
            newUser.Position = "doctor";
            newUser.CreatedAt = DateTime.UtcNow;
            newUser.UpdatedAt = DateTime.UtcNow;

            await _authorizationRepository.Create(newUser);

            return new OkObjectResult("Registration successful");
        }

        public async Task<ActionResult<UserDTO>> GetUserAuthorize(int id)
        {
            var user = await _authorizationRepository.GetById(id);

            if (user == null)
            {
                return new NotFoundObjectResult("User do not exist");
            }

            var userDTO = _mapper.Map<UserDTO>(user);

            return new OkObjectResult(userDTO);
        }

        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _authorizationRepository.GetById(id);

            if (user == null)
            {
                return new NotFoundObjectResult("User do not exist");
            }

            var userDTO = _mapper.Map<User>(user);

            return new OkObjectResult(userDTO);
        }
    }
}
