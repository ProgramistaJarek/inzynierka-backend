using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IVaccinationsRepository : IRepositoryBase<Vaccinations>
    {
        Task<IEnumerable<Vaccinations>> ReturnVaccinationBeforeExirationDate();
        Task<IEnumerable<Vaccinations>> GetVaccinationExpiringWithinDays(int days);
        Task<bool> ReduceVaccinationLeft(int id, int count);
    }
}
