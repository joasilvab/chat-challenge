using System;

namespace ChatApi.Domain
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual string Message { get; set; }
        public virtual User User { get; set; }
    }
}
