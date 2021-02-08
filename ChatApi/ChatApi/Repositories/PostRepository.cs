using System;
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
        //public void Delete(Post post)
        //{
        //    using (ISession session = NHibernateHelper.OpenSession())
        //    using (ITransaction transaction = session.BeginTransaction())
        //    {
        //        session.Delete(post);
        //        transaction.Commit();
        //    }
        //}

        //public Post Get(Guid id)
        //{
        //    using (ISession session = NHibernateHelper.OpenSession())
        //        return session.Get<Post>(id);
        //}
        public Task<List<Post>> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Query<Post>().Fetch(p => p.User).ToListAsync();
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

        //public void Update(Post post)
        //{
        //    using (ISession session = NHibernateHelper.OpenSession())
        //    using (ITransaction transaction = session.BeginTransaction())
        //    {
        //        session.Update(post);
        //        transaction.Commit();
        //    }
        //}
    }
}
