using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Api.Application.Notifications;
public class OrderNotification
{
    public string? OrderId { get; set; }
    public DateTime? OrderDate { get; set; }
}