using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IVaccinationsRepository : IRepositoryBase<Vaccinations>
    {
        Task<IEnumerable<Vaccinations>> ReturnVaccinationBeforeExirationDate();
    }
}
