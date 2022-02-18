using Microsoft.AspNetCore.SignalR;
using Powers.SignaIR.Demo.Models;

namespace Powers.SignaIR.Demo.Services
{
    public class ChatHub : Hub
    {
        private readonly ChatService _chatService;

        public ChatHub(ChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task GetMessages(string connectionId)
        {
            var data = _chatService.Messages;
            await Clients.Client(connectionId).SendAsync("GetMessages", data);
        }

        public async Task SendMessage(string username, string content, string clientName)
        {
            var msg = new ChatMessage
            {
                UserName = username,
                Content = content,
                SendedTime = DateTime.Now,
                ClientName = clientName,
            };
            _chatService.Messages.Add(msg);

            await Clients.All.SendAsync("SendMessage", msg);
        }

        public override Task OnConnectedAsync()
        {
            _ = GetMessages(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}