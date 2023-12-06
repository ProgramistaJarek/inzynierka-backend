using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class PatientBabysitterRepository : RepositoryBase<PatientBabysitter>, IPatientBabysitterRepository
    {
        private readonly DatabaseContext _context;

        public PatientBabysitterRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
