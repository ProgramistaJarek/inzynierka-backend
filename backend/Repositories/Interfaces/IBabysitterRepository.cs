using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IBabysitterRepository : IRepositoryBase<Babysitter>
    {
        Task<Babysitter> CheckIfBabysitterExistByPesel(string pesel);
    }
}
