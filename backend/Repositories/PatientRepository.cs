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
            var patient = await _context.Set<Patient>()
                .Include(b => b.Babysitter)
                .Include(card => card.VaccinationCard)
                .FirstOrDefaultAsync(patient => patient.Id == id);

            if (patient != null)
            {
                return patient;
            }
            else
            {
                return null!;
            }
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _context.Set<Patient>()
                .ToListAsync();

            if (patients != null)
            {
                return patients;
            }
            else
            {
                return null!;
            }
        }
    }
}
