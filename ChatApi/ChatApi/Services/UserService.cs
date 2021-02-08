using System.Threading.Tasks;
using ChatApi.Domain;
using ChatApi.Repositories;

namespace ChatApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<User> GetUserByUsername(string username)
        {
            var user = await userRepository.GetByUsername(username);
            return user;
        }
    }
}
