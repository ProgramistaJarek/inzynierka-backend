using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class VaccinationsRepository : RepositoryBase<Vaccinations>, IVaccinationsRepository
    {
        public VaccinationsRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
