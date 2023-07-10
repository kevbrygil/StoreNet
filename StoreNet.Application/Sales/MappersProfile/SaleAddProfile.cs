using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreNet.Domain.Entities;
using AutoMapper;
using StoreNet.Application.Sales.Dtos;

namespace StoreNet.Application.Sales.MappersProfile
{
    public class SaleAddProfile : Profile
    {
        public SaleAddProfile() {
            CreateMap<Sale, SaleAddDto>();
            CreateMap<SaleAddDto, Sale>();
        }
    }
}
