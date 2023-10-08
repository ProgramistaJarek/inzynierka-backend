using backend.Entities;
using backend.ModelsDTO;

namespace backend.Repositories
{
    public interface IAuthorizationRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByNickname(string nickname);
    }
}
