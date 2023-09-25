using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace backend.Services.Authorization
{
    public class PasswordHash
    {
        public string CreatePasswordHash(string password, byte[] salt)
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

        public bool VerifyPassword(string enterPassword, string storedHash, byte[] storedSalt)
        {
            string hashToCompare = CreatePasswordHash(enterPassword, storedSalt);
            return hashToCompare == storedHash;
        }
    }
}
