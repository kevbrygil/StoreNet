using AutoMapper;
using StoreNet.Application.Auth.Dtos;
using StoreNet.Domain.Entities;

namespace StoreNet.Application.Auth.MappersProfile
{
    public class AuthTokenProfile:Profile
    {
        public AuthTokenProfile() {
            CreateMap<User, AuthLoginDto>();
            CreateMap<AuthLoginDto, User>();
        }
        
    }
}
