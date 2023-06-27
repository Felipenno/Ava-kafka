using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Orders.Api.Application.Dto;

namespace Orders.Api.Application.Command.Orders;
public class AddOrderCommand : IRequest<OrderDto>
{
    public OrderRequest? Order { get; set; }
}