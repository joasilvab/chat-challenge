using AutoMapper;
using ChatApi.Domain;

namespace ChatApi.Models.Automapper
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostRequest>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(y => y.User.Username))
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.MapFrom(y => new User { Username = y.Username }));
        }
    }
}
