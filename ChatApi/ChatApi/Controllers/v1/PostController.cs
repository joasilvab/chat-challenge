using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Models;
using ChatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostController
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostRequest>>> GetPosts()
        {
            var posts = await postService.GetPosts();
            return posts;
        }
    }
}
