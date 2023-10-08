using backend.Entities;
using backend.Database;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class VaccinationsRepository : IVaccinationsRepository
    {
        private readonly DatabaseContext _context;

        public VaccinationsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vaccinations>> GetVaccinationsAsync()
        {
            return await _context.Vaccinations.ToListAsync();
        }

        public async Task<Vaccinations> GetVaccinateByIdAsync(int id)
        {
            return await _context.Vaccinations.FindAsync(id);
        }

        public async Task AddVaccinateAsync(Vaccinations vaccinations)
        {
            _context.Vaccinations.Add(vaccinations);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVaccinateAsync(Vaccinations vaccinations)
        {
            _context.Entry(vaccinations).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeteleVaccinateAsync(int id)
        {
            var vaccinate = await GetVaccinateByIdAsync(id);
            if (vaccinate != null)
            {
                _context.Vaccinations.Remove(vaccinate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
