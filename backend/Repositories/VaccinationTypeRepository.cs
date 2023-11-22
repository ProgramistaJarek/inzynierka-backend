using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class VaccinationTypeRepository : RepositoryBase<VaccinationType>, IVaccinationTypeRepository
    {
        public VaccinationTypeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
