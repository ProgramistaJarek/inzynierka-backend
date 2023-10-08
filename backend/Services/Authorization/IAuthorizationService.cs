using backend.Entities;
using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Authorization
{
    public interface IAuthorizationService
    {
        Task<ActionResult<UserDTO>> LoginUser(LoginDTO loginDTO);
        Task<ActionResult<UserDTO>> SignupUser(SignupDTO signupDTO);
        Task<ActionResult<UserDTO>> GetUserAuthorize(int id);
        Task<ActionResult<UserDTO>> GetUserById(int id);
        /*string CreatePasswordHash(string password, byte[] salt);
        bool VerifyPassword(string enterPassword, string storedHash, byte[] storedSalt);
        string GenerateJWT(User user);*/
    }
}
