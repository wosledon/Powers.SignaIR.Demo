using Microsoft.AspNetCore.SignalR;
using Powers.SignaIR.Demo.Models;

namespace Powers.SignaIR.Demo.Services
{
    public class ChatService
    {
        private readonly List<ChatMessage> _messages;
        private readonly IHubContext<ChatHub> _context;

        public List<ChatMessage> Messages => _messages;

        public ChatService(IHubContext<ChatHub> context)
        {
            _context = context;
            _messages = new List<ChatMessage>();
        }
    }
}