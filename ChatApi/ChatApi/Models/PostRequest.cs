using System;

namespace ChatApi.Models
{
    public class PostRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
