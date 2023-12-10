using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IOtherVaccinationRepository : IRepositoryBase<OtherVaccination>
    {
        Task<IEnumerable<OtherVaccination>> GetOtherVaccinvationByCardId(int id);
    }
}
