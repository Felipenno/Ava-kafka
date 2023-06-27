using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Email.Domain.Entities;
using Orders.Email.Domain.Interfaces;

namespace Orders.Email.Repositories;
public class OrderRepository : IOrderRepository
{
    private IMongodbServiceHandler<Order, string> Repository { get; }

    public OrderRepository(IMongodbServiceHandler<Order, string> repository)
    {
        Repository = repository;
    }

    public async Task<Order> getOrderByOrderId(string orderId)
    {
        return await Repository.GetSingleAsync(x => x.OrderId == orderId);
    }
}