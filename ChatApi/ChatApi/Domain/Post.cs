using System;

namespace ChatApi.Domain
{
    public class Post
    {
        public virtual Guid Id { get; set; }
        public virtual string Message { get; set; }
    }
}
