using backend.Models;

namespace backend.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientById(int id);
        Task AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
    }
}
