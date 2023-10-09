using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class VaccinationInfoRepository : RepositoryBase<VaccinationInfo>, IVaccinationInfoRepository
    {
        public VaccinationInfoRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
