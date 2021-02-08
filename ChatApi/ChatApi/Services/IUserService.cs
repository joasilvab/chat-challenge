using System.Threading.Tasks;
using ChatApi.Domain;

namespace ChatApi.Services
{
    public interface IUserService
    {
        Task<User> GetUserByUsername(string username);
    }
}
