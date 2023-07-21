using AutoMapper;
using StoreNet.Application.Auth.Dtos;
using StoreNet.Domain.Entities;

namespace StoreNet.Application.Auth.MappersProfile
{
    public class AuthLoginProfile:Profile
    {
        public AuthLoginProfile() {
            CreateMap<User, AuthLoginDto>();
            CreateMap<AuthLoginDto, User>();
        }
        
    }
}
