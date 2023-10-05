using backend.Models;

namespace backend.Repositories
{
    public interface IVaccinationsRepository
    {
        Task<IEnumerable<Vaccinations>> GetVaccinationsAsync();
        Task<Vaccinations> GetVaccinateByIdAsync(int id);
        Task AddVaccinateAsync(Vaccinations vaccinations);
        Task UpdateVaccinateAsync(Vaccinations vaccinations);
        Task DeteleVaccinateAsync(int id);
    }
}
