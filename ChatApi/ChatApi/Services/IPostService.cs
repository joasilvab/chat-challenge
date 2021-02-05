using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Models;

namespace ChatApi.Services
{
    public interface IPostService
    {
        Task SavePost(MessageRequest message);
        Task<List<MessageRequest>> GetPosts();
    }
}
