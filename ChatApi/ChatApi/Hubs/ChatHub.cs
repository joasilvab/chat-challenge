using System.Threading.Tasks;
using ChatApi.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatApi.Hubs
{
    public class ChatHub: Hub
    {
        public async Task NewMessage(MessageRequest message)
        {
            await Clients.All.SendAsync("MessageReceived", message);
        }
    }
}
