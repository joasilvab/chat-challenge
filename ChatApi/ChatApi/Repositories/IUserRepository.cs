using System.Threading.Tasks;
using ChatApi.Domain;

namespace ChatApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsername(string username);
    }
}
