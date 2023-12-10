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
    }
}
