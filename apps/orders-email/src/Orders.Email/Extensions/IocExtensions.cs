using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Orders.Email.Domain.Entities;
using Orders.Email.Domain.Interfaces;
using Orders.Email.Domain.Services;
using Orders.Email.Domain.Services.EmailHandler;
using Orders.Email.Domain.Services.EventHandler;
using Orders.Email.Repositories;
using Orders.Email.Settings;
using SendGrid.Extensions.DependencyInjection;

namespace Orders.Email.Extensions;
public static class IocExtensions
{
    public static void AddIoc(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddSingleton<IEventhandlerService, EventHandlerService>();
        services.AddSendGrid(options =>
        {
            options.ApiKey = configuration["Email:Email_key"];
        });

        services.AddSingleton<IMessageServicehandler, EmailServiceHandler>();

        services.Configure<MongodbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddSingleton<IMongodbServiceHandler<Order, string>, MongoDbServiceHandler<Order, string>>();
        services.AddSingleton<IOrderRepository, OrderRepository>();
    }
}