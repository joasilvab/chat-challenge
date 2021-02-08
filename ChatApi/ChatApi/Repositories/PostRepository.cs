using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApi.Database;
using ChatApi.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ChatApi.Repositories
{
    public class PostRepository : IPostRepository
    {
        public Task<List<Post>> Get(int quantity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Query<Post>().OrderByDescending(p => p.Timestamp).Take(quantity).Fetch(p => p.User).ToListAsync();
        }

        public async Task Save(Post post)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                await session.SaveAsync(post);
                transaction.Commit();
            }
        }
    }
}
