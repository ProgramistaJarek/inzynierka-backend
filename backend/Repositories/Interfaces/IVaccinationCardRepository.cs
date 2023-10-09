using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IVaccinationCardRepository : IRepositoryBase<VaccinationCard>
    {
        Task<VaccinationCard> GetVaccinationCardByPatientId(int id);
    }
}
