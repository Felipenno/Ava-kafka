using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Api.Domain.Interfaces;

    public interface IEventHandlerService
    {
        Task<bool> produceMessage<T>(string topic, T content);
    }
