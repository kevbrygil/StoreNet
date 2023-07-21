using AutoMapper;
using StoreNet.Application.Users.Dtos;
using StoreNet.Domain.Entities;

namespace StoreNet.Application.Users.MappersProfile
{
    public class UserAddProfile: Profile
    {
        public UserAddProfile()
        {
            CreateMap<User, UserAddDto>();
            CreateMap<UserAddDto, User>();
        }
    }
}
