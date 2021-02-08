using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Models;

namespace ChatApi.Services
{
    public interface IPostService
    {
        Task SavePost(PostRequest message);
        Task<List<PostRequest>> GetPosts();
    }
}
