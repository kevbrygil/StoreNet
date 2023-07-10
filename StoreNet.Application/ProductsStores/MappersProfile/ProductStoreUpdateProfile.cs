using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreNet.Domain.Entities;
using AutoMapper;
using StoreNet.Application.ProductsStores.Dtos;

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
