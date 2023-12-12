using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Vaccinations>> GetVaccinationExpiringWithinDays(int days)
        {
            DateTime currentDate = DateTime.Today;
            DateTime daysLater = currentDate.AddDays(days);

            var result = await _context.Set<Vaccinations>()
                        .Where(v => v.ExpirationDate >= currentDate && v.ExpirationDate <= daysLater)
                        .ToListAsync();

            return result;
        }

        public async Task<bool> ReduceVaccinationLeft(int id, int count)
        {
            var vaccination = await _context.Vaccinations.FirstOrDefaultAsync(v => v.Id == id);

            if (vaccination != null && vaccination.Left > 0)
            {
                vaccination.Left -= count;

                _context.Vaccinations.Update(vaccination);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
