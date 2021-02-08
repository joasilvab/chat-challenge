using System;
using System.Threading.Tasks;
using ChatApi.Models;
using ChatApi.Services;
using Microsoft.AspNetCore.SignalR;

namespace ChatApi.Hubs
{
    public class ChatHub: Hub
    {
        private readonly IPostService postService;
        public ChatHub(IPostService postService)
        {
            this.postService = postService;
        }
        public async Task NewMessage(PostRequest message)
        {
            message.Timestamp = DateTime.Now;
            await postService.SavePost(message);
            await Clients.All.SendAsync("MessageReceived", message);
        }
    }
}
