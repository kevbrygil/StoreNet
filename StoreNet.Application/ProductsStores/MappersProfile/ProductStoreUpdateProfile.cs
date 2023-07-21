using AutoMapper;
using StoreNet.Application.ProductsStores.Dtos;
using StoreNet.Domain.Entities;

namespace StoreNet.Application.ProductsStores.MappersProfile
{
    public class ProductStoreUpdateProfile : Profile
    {
        public ProductStoreUpdateProfile() {
            CreateMap<ProductStore, ProductStoreUpdateDto>();
            CreateMap<ProductStoreUpdateDto, ProductStore>();
        }
    }
}
