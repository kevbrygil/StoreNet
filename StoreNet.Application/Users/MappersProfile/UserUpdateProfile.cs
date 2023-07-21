using AutoMapper;
using StoreNet.Application.Users.Dtos;
using StoreNet.Domain.Entities;

namespace StoreNet.Application.Users.MappersProfile
{
    public class UserUpdateProfile: Profile
    {
        public UserUpdateProfile()
        {
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
