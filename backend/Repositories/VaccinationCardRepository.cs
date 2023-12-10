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
            var card = await _context.Set<VaccinationCard>()
                .Include(patient => patient.Patient)
                .FirstOrDefaultAsync(card => card.Id == id);

            if (card != null)
            {
                return card;
            }
            else
            {
                return null!;
            }
        }

        public async Task<VaccinationCard> GetVaccinationCardByPatientId(int id)
        {
            var card = await _context.Set<VaccinationCard>()
                .FirstOrDefaultAsync(card => card.PatientId == id);

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
