using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Orders.Api.Application.Dto;
using Orders.Api.Domain.Entities;

namespace Orders.Api.Application.Mappings.Profiles;
public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderRequest, Order>()
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDate, opt => opt.Ignore())
                .ForMember(dest => dest.ShippingDate, opt => opt.Ignore())
                .ForMember(dest => dest.OrderStatus, opt => opt.Ignore());
        }
    }