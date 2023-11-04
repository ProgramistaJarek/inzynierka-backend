using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        Task<Patient> CheckIfPatientExistByPesel(string pesel);
        Task<Patient> GetPatient(int id);
        Task<IEnumerable<Patient>> GetPatients();
    }
}
