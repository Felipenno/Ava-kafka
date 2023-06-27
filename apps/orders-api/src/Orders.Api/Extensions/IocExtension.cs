using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Orders.Api.Domain.Entities;
using Orders.Api.Domain.Interfaces;
using Orders.Api.Domain.Services;
using Orders.Api.Repositories;
using Orders.Api.Settings;

namespace Orders.Api.Extensions;

public static class IocExtension
{
    public static void AddIoc( this IServiceCollection services, IConfiguration config)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IEventHandlerService, EventHandlerService>();

        services.Configure<MongoDbSettings>(config.GetSection("MongoDbSettings"));
        services.AddSingleton<IMongoDbServiceHandler<Order, string>, MongoDbServiceHandler<Order, string>>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}
