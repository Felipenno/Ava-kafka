using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Orders.Api.Application.Dto;
using Orders.Api.Application.Notifications;
using Orders.Api.Domain.Entities;
using Orders.Api.Domain.Interfaces;

namespace Orders.Api.Application.Command.Orders;
public class OrderHandler : IRequestHandler<AddOrderCommand, OrderDto>
{
    private readonly ILogger<OrderHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _ordersRepository;
    private readonly IEventHandlerService _eventHandlerService;

    public OrderHandler(ILogger<OrderHandler> logger, IMapper mapper, IOrderRepository ordersRepository, IEventHandlerService eventHandlerService)
    {
        _logger = logger;
        _mapper = mapper;
        _ordersRepository = ordersRepository;
        _eventHandlerService = eventHandlerService;
    }

    public async Task<OrderDto> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Order>(request.Order);

        _logger.LogInformation("Save order on database");
        await _ordersRepository.InsertOrderAsync(result);

        _logger.LogInformation("Produce message");
        var notification = new OrderNotification
        {
            OrderId = result.OrderId,
            OrderDate = result.OrderDate
        };

        await _eventHandlerService.produceMessage<OrderNotification>("send-email", notification);

        return await Task.FromResult(new OrderDto
        {
            Message = $"order nº {notification.OrderId} created at {result.OrderDate:dd/MM/yyyy}",
            orderId = result.OrderId
        });

    }
}