using AutoMapper;

namespace ChatApi.Models.Automapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.User, Models.User>()
                .ReverseMap();
        }
    }
}
