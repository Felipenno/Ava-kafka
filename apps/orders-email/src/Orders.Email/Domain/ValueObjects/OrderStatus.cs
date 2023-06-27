using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Email.Domain.ValueObjects;
public enum OrderStatus
{
    Pending,
    InProgress,
    Shipped,
    Delivered,
    Cancelled,
    Refunded,
    Returned
}