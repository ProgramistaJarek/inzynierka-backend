using backend.Database;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PatientBabysitterRepository : RepositoryBase<PatientBabysitter>, IPatientBabysitterRepository
    {
        private readonly DatabaseContext _context;

        public PatientBabysitterRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PatientBabysitter> DoesPatientBabysitterExist(int babysitterId, int patientId)
        {
            var exists = await _context.Set<PatientBabysitter>()
                .FirstOrDefaultAsync(pb => pb.PatientId == patientId && pb.BabysitterId == babysitterId);

            return exists;
        }

        public async Task RemovePatientBabysitter(PatientBabysitter patientBabysitter)
        {
            _context.Remove(patientBabysitter);
            await _context.SaveChangesAsync();
        }
    }
}
