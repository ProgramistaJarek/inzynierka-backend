using backend.Database;
using backend.Entities;

namespace backend.Repositories
{
    public class BabysitterRepository : RepositoryBase<Babysitter>, IBabysitterRepository
    {
        public BabysitterRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
