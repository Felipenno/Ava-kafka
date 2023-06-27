using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Api.Application.Dto;

public class OrderDto
{
    public string? Message { get; set; }
    public string? orderId { get; set; }
}
