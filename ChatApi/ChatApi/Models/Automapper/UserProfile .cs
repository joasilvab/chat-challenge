using System;
using AutoMapper;
using ChatApi.Domain;

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
