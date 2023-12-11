using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class VaccinationInfoRepository : RepositoryBase<VaccinationInfo>, IVaccinationInfoRepository
    {
        private readonly DatabaseContext _context;

        public VaccinationInfoRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VaccinationInfo>> GetVaccinationInfoByCardId(int id)
        {
            return await _context.Set<VaccinationInfo>().Include(e => e.TypeVaccinations).Include(e => e.AgeGroups).Include(e => e.Vaccinations).Where(x => x.VaccinationCardId == id).ToListAsync();
        }

        public async Task<IEnumerable<VaccinationInfo>> GetLatestScheduledVaccination(int count, DateTime date)
        {
            var result = await _context.Set<VaccinationInfo>()
                .Where(info => info.ScheduledVaccination.Date == date.Date)
                .OrderByDescending(info => info.ScheduledVaccination)
                .Include(info => info.VaccinationCard)
                .Include(info => info.AgeGroups)
                .Include(info => info.TypeVaccinations)
                .Include(info => info.Vaccinations)
                .Take(count)
                .ToListAsync();

            return result;
        }
    }
}
