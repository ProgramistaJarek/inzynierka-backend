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
    }
}
