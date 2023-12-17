using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class OtherVaccinationRepository : RepositoryBase<OtherVaccination>, IOtherVaccinationRepository
    {
        private readonly DatabaseContext _context;

        public OtherVaccinationRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OtherVaccination>> GetOtherVaccinvationByCardId(int id)
        {
            var card = await _context.Set<OtherVaccination>()
                .Include(info => info.VaccinationCard)
                .Include(info => info.Vaccinations)
                .Where(card => card.VaccinationCardId == id)
                .ToListAsync();

            if (card != null)
            {
                return card;
            }
            else
            {
                return null!;
            }
        }

        public async Task<bool> CheckIfVaccinationExist(OtherVaccination updateEntity)
        {
            var result = await _context.Set<OtherVaccination>()
                           .Where(info => info.TypeVaccination == updateEntity.TypeVaccination && info.VaccinationId == updateEntity.VaccinationId && info.Dose == updateEntity.Dose && info.VaccinationCardId == updateEntity.VaccinationCardId)
                           .FirstOrDefaultAsync();

            if (result != null)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<bool> CheckIfVaccinationExistWithId(OtherVaccination updateEntity)
        {
            var result = await _context.Set<OtherVaccination>()
                           .Where(info => info.TypeVaccination == updateEntity.TypeVaccination && info.VaccinationId == updateEntity.VaccinationId && info.Dose == updateEntity.Dose && info.VaccinationCardId == updateEntity.VaccinationCardId && info.Id != updateEntity.Id)
                           .FirstOrDefaultAsync();

            return result != null;
        }
    }
}
