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
    public class ProductStoreAddProfile : Profile
    {
        public ProductStoreAddProfile() {
            CreateMap<ProductStore, ProductStoreAddDto>();
            CreateMap<ProductStoreAddDto, ProductStore>();
        }
    }
}
