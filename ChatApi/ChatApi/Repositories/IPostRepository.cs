using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Domain;

namespace ChatApi.Repositories
{
    public interface IPostRepository
    {
        Post Get(Guid id);
        Task<List<Post>> GetAll();
        Task Save(Post post);
        void Update(Post post);
        void Delete(Post post);
    }
}
