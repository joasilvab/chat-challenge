namespace ChatApi.Models
{
    public class MessageRequest
    {
        public int Id { get; set; } 
        public User User { get; set; }
        public string Message { get; set; }
    }
}
