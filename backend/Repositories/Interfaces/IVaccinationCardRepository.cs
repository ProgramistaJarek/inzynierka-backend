using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IVaccinationCardRepository : IRepositoryBase<VaccinationCard>
    {
        Task<VaccinationCard> GetVaccinationCardByPatientId(int id);
        Task<VaccinationCard> GetVaccinationCardById(int id);
        Task<IEnumerable<VaccinationCard>> GetScheduledVaccinationInfo(int count);
    }
}
