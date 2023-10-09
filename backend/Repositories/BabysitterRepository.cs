using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class BabysitterRepository : RepositoryBase<Babysitter>, IBabysitterRepository
    {
        private readonly DatabaseContext _context;

        public BabysitterRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Babysitter> CheckIfBabysitterExistByPesel(string pesel)
        {
            return await _context.Set<Babysitter>().FirstOrDefaultAsync(user => user.PESEL == pesel);
        }
    }
}
