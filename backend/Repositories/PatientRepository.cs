using backend.Database;
using backend.Entities;

namespace backend.Repositories
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
