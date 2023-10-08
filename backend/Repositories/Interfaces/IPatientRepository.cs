using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        Task<Patient> CheckIfUsernameExistByPesel(string pesel);
    }
}
