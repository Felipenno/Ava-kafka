using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Orders.Api.Domain.Interfaces;

namespace Orders.Api.Domain.Services;

public class EventHandlerService : IEventHandlerService
{
    private ILogger<EventHandlerService> Logger { get; set; }
    private IConfiguration Config { get; }
    private ProducerConfig producerConfiguration { get; }

    public EventHandlerService(
        ILogger<EventHandlerService> logger,
        IConfiguration config)
    {
        Logger = logger;
        Config = config;
        producerConfiguration = new ProducerConfig
        {
            BootstrapServers = config["Events:BootstrapServers"]
        };
    }

    public async Task<bool> produceMessage<T>(string topic, T content)
    {
        var messageContent = new Message<Null, T>
        {
            Value = content
        };

        using var producer = new ProducerBuilder<Null, T>(producerConfiguration)
                .SetValueSerializer(new CustomSerializer<T>())
                .Build();

        var sendMessage = await producer.ProduceAsync(topic, messageContent);
        producer.Flush(TimeSpan.FromSeconds(5));

        return sendMessage.Status == PersistenceStatus.Persisted;
    }
}
