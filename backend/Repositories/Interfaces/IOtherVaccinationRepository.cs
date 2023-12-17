using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IOtherVaccinationRepository : IRepositoryBase<OtherVaccination>
    {
        Task<IEnumerable<OtherVaccination>> GetOtherVaccinvationByCardId(int id);
        Task<bool> CheckIfVaccinationExist(OtherVaccination updateEntity);
        Task<bool> CheckIfVaccinationExistWithId(OtherVaccination updateEntity);
    }
}
