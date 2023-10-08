using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class BabysitterRepository : RepositoryBase<Babysitter>, IBabysitterRepository
    {
        public BabysitterRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
