using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        private readonly DatabaseContext _context;

        public PatientRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Patient> CheckIfPatientExistByPesel(string pesel)
        {
            return await _context.Set<Patient>().FirstOrDefaultAsync(user => user.PESEL == pesel);
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _context.Set<Patient>()
                .Include(b => b.Babysitter)
                .Include(card => card.VaccinationCard)
                .Include(patient => patient.VaccinationCard.VaccinationInfo)
                .FirstOrDefaultAsync(patient => patient.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _context.Set<Patient>()
                .Include(b => b.Babysitter)
                .Include(card => card.VaccinationCard)
                .Include(patient => patient.VaccinationCard.VaccinationInfo)
                .ToListAsync();
        }
    }
}
