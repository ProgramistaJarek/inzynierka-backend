using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class SummonsRepository : RepositoryBase<Summons>, ISummonsRepository
    {
        public SummonsRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
