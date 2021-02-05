using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChatApi.Domain;
using ChatApi.Models;
using ChatApi.Repositories;

namespace ChatApi.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;
        public PostService(IPostRepository postRepository,
                           IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task<List<MessageRequest>> GetPosts()
        {
            var posts = await this.postRepository.GetAll();
            return mapper.Map<List<MessageRequest>>(posts);
        }

        public async Task SavePost(MessageRequest message)
        {
            var post = mapper.Map<Post>(message);
            await postRepository.Save(post);
        }
    }
}
