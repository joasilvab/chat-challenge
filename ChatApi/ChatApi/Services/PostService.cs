using System;
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
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public PostService(IPostRepository postRepository,
                           IUserService userService,
                           IMapper mapper)
        {
            this.postRepository = postRepository;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<List<PostRequest>> GetPosts()
        {
            var posts = await this.postRepository.GetAll();
            return mapper.Map<List<PostRequest>>(posts);
        }

        public async Task SavePost(PostRequest message)
        {
            var post = mapper.Map<Post>(message);
            var user = await userService.GetUserByUsername(message.Username);
            post.User = user;
            await postRepository.Save(post);
        }
    }
}
