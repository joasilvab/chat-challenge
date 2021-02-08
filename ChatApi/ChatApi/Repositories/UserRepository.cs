using System.Linq;
using System.Threading.Tasks;
using ChatApi.Database;
using ChatApi.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ChatApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetByUsername(string username)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Query<User>().Where(u => u.Username == username).SingleOrDefaultAsync();

        }
    }
}
