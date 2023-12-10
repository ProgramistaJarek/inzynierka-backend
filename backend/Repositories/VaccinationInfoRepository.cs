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
    }
}
