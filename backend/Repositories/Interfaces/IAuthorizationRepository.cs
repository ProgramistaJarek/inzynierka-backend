using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IAuthorizationRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByNickname(string nickname);
    }
}
