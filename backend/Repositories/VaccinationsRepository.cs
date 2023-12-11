using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class VaccinationsRepository : RepositoryBase<Vaccinations>, IVaccinationsRepository
    {
        private readonly DatabaseContext _context;
        public VaccinationsRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vaccinations>> ReturnVaccinationBeforeExirationDate()
        {
            DateTime currentDate = DateTime.UtcNow;

            var expiredVaccinations = _context.Vaccinations
                .Where(v => v.ExpirationDate > currentDate)
                .ToList();

            return expiredVaccinations;
        }
    }
}
