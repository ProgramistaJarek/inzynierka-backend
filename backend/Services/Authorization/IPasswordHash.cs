namespace backend.Services.Authorization
{
    public interface IPasswordHash
    {
        string CreatePasswordHash(string password, byte[] salt);
        bool VerifyPassword(string enterPassword, string storedHash, byte[] storedSalt);
    }
}
