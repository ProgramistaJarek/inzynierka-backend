using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class AgeGroupsRepository : RepositoryBase<AgeGroups>, IAgeGroupsRepository
    {
        public AgeGroupsRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
