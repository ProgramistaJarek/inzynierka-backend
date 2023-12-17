using backend.Database;
using backend.Entities;
using backend.ModelsDTO;
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
                .ThenInclude(card => card.Patient)
                .Include(info => info.AgeGroups)
                .Include(info => info.TypeVaccinations)
                .Include(info => info.Vaccinations)
                .Take(count)
                .ToListAsync();

            return result;
        }

        public async Task<bool> CheckIfVaccinationExist(VaccinationInfo updateEntity)
        {
            var result = await _context.Set<VaccinationInfo>()
                           .Where(info => info.AgeGroupId == updateEntity.AgeGroupId && info.TypeVaccinationId == updateEntity.TypeVaccinationId && info.VaccinationId == updateEntity.VaccinationId && info.Dose == updateEntity.Dose && info.VaccinationCardId == updateEntity.VaccinationCardId)
                           .FirstOrDefaultAsync();

            if (result != null)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<bool> CheckIfVaccinationExistWithId(VaccinationInfo updateEntity)
        {
            var result = await _context.Set<VaccinationInfo>()
                           .Where(info => info.AgeGroupId == updateEntity.AgeGroupId && info.TypeVaccinationId == updateEntity.TypeVaccinationId && info.VaccinationId == updateEntity.VaccinationId && info.Dose == updateEntity.Dose && info.VaccinationCardId == updateEntity.VaccinationCardId && info.Id != updateEntity.Id)
                           .FirstOrDefaultAsync();

            return result != null;
        }
    }
}
