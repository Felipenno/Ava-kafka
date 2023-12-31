using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Orders.Api.Domain.Entities;
using Orders.Api.Domain.Interfaces;

namespace Orders.Api.Repositories;
public class OrderRepository : IOrderRepository
{
    private IMongoDbServiceHandler<Order, string> Repository { get; }

    public OrderRepository(IMongoDbServiceHandler<Order, string> repository)
    {
        Repository = repository;
    }

    public async Task<IEnumerable<Order>> getAllOrdersAsync()
    {
        return await Repository.GetAllAsync(_ => true);
    }

    public async Task<Order> GetSingleOrderAsync(string id)
    {
        return await Repository.GetSingleAsync(order => order.OrderId == id);
    }

    public async Task InsertOrderAsync(Order entity)
    {
        await Repository.InsertAsync(entity);
    }

    public async Task RemoveOrderAsync(string id)
    {
        await Repository.RemoveAsync(id);
    }

    public async Task<ReplaceOneResult> UpdateOrderAsync(string id, Order entity)
    {
        return await Repository.UpdateAsync(id, entity);
    }
}