using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class VaccinationCardRepository : RepositoryBase<VaccinationCard>, IVaccinationCardRepository
    {
        public VaccinationCardRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
