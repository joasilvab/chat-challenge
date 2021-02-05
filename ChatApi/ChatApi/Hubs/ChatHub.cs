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
        public async Task NewMessage(MessageRequest message)
        {
            await postService.SavePost(message);
            await Clients.All.SendAsync("MessageReceived", message);
        }
    }
}
