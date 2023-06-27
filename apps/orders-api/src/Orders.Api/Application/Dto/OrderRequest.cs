using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Api.Domain.Entities;
using Orders.Api.Domain.ValueObject;

namespace Orders.Api.Application.Dto;
public class OrderRequest
{
    public Customer? Customer { get; set; }
    public IList<Product>? Products { get; set; }
    public PaymentType PaymentType { get; set; }
    public decimal OrderTotal { get; set; }
    public ShippingType ShippingType
    {
        get; set;
    }
}