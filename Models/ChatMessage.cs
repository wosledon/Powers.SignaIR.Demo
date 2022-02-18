namespace Powers.SignaIR.Demo.Models
{
    public class ChatMessage
    {
        public string? UserName { get; set; }
        public string? Content { get; set; }
        public DateTime SendedTime { get; set; }
        public string? ClientName { get; set; }
    }
}