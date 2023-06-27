using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Email.Domain.Entities;

namespace Orders.Email.Domain.Interfaces;
public interface IOrderRepository
{
    Task<Order> getOrderByOrderId(string orderId);
}