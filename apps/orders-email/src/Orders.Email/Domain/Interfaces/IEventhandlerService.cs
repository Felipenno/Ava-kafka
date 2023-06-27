using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Email.Domain.Interfaces;
public interface IEventhandlerService
{
    Task<T?> ConsumeMessage<T>(CancellationToken cancellationToken);
}