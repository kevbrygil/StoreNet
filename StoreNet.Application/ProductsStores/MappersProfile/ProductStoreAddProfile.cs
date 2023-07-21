using AutoMapper;
using StoreNet.Application.ProductsStores.Dtos;
using StoreNet.Domain.Entities;

namespace StoreNet.Application.ProductsStores.MappersProfile
{
    public class ProductStoreAddProfile : Profile
    {
        public ProductStoreAddProfile() {
            CreateMap<ProductStore, ProductStoreAddDto>();
            CreateMap<ProductStoreAddDto, ProductStore>();
        }
    }
}
