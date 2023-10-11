using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IVaccinationInfoRepository : IRepositoryBase<VaccinationInfo>
    {
        Task<IEnumerable<VaccinationInfo>> GetVaccinationInfoByCardId(int id);
    }
}
