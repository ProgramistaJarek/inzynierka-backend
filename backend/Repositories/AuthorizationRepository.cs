using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class AuthorizationRepository : RepositoryBase<User>, IAuthorizationRepository
    {
        private readonly DatabaseContext _context;

        public AuthorizationRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByNickname(string nickname)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Nickname == nickname);
        }
    }
}
