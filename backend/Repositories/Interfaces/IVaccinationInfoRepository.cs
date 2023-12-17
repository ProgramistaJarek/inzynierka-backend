using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IVaccinationInfoRepository : IRepositoryBase<VaccinationInfo>
    {
        Task<IEnumerable<VaccinationInfo>> GetVaccinationInfoByCardId(int id);
        Task<IEnumerable<VaccinationInfo>> GetLatestScheduledVaccination(int count, DateTime date);
        Task<bool> CheckIfVaccinationExist(VaccinationInfo updateEntity);
        Task<bool> CheckIfVaccinationExistWithId(VaccinationInfo updateEntity);
    }
}
