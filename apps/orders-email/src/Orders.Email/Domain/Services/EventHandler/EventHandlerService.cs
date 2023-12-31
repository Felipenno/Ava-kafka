using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Confluent.Kafka;
using Orders.Email.Domain.Interfaces;

namespace Orders.Email.Domain.Services.EventHandler;
public class EventHandlerService : IEventhandlerService
{
    private ILogger<EventHandlerService> Logger { get; }
    private IConfiguration Config { get; }
    private ConsumerConfig ConsumerConfig { get; }
    private IConsumer<Ignore, string> Consumer { get; }

    public EventHandlerService(
        ILogger<EventHandlerService> logger,
        IConfiguration config)
    {
        Logger = logger;
        Config = config;
        ConsumerConfig = new()
        {
            BootstrapServers = Config["Events:BootstrapServers"],
            GroupId = config["Events:GroupId"],
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        Consumer = new ConsumerBuilder<Ignore, string>(ConsumerConfig).Build();

        Consumer.Subscribe(Config["Events:Topic"]);
    }

    public Task<T?> ConsumeMessage<T>(CancellationToken cancellationToken)
    {
        var url = Config["Events:BootstrapServers"];
        var cancellationTokenSource = new CancellationTokenSource();
        var consume = Consumer.Consume(cancellationTokenSource.Token);

        var result = JsonSerializer.Deserialize<T>(consume.Message.Value);

        return Task.FromResult(result);
    }
}