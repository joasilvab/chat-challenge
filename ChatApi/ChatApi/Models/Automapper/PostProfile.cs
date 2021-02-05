using AutoMapper;
using ChatApi.Domain;

namespace ChatApi.Models.Automapper
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<Post, MessageRequest>()
                .ReverseMap();
        }
    }
}
