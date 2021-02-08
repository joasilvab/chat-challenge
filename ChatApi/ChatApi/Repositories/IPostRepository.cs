using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Domain;

namespace ChatApi.Repositories
{
    public interface IPostRepository
    {
        Task<List<Post>> Get(int quantity);
        Task Save(Post post);
    }
}
