using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class VaccinationCardRepository : RepositoryBase<VaccinationCard>, IVaccinationCardRepository
    {
        private readonly DatabaseContext _context;

        public VaccinationCardRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VaccinationCard> GetVaccinationCardById(int id)
        {
            return await _context.Set<VaccinationCard>()
                .Include(info => info.VaccinationInfo)
                .FirstOrDefaultAsync(card => card.Id == id);
        }

        public async Task<VaccinationCard> GetVaccinationCardByPatientId(int id)
        {
            return await _context.Set<VaccinationCard>()
                .Include(info => info.VaccinationInfo)
                .FirstOrDefaultAsync(card => card.PatientId == id);
        }
    }
}
