using backend.Entities;

namespace backend.Services.Authorization
{
    public interface IAuthorizationService
    {
        string CreatePasswordHash(string password, byte[] salt);
        bool VerifyPassword(string enterPassword, string storedHash, byte[] storedSalt);
        string GenerateJWT(User user);
    }
}
