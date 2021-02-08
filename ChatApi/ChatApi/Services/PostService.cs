using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatApi.Domain;
using ChatApi.Models;
using ChatApi.Repositories;
using Microsoft.Extensions.Configuration;

namespace ChatApi.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public PostService(IPostRepository postRepository,
                           IUserService userService,
                           IConfiguration configuration,
                           IMapper mapper)
        {
            this.postRepository = postRepository;
            this.userService = userService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<List<PostRequest>> GetPosts()
        {
            var postsQuantity = configuration.GetValue<int>("postsQuantity");
            var posts = await this.postRepository.Get(postsQuantity);
            posts = posts.OrderBy(p => p.Timestamp).ToList();
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
