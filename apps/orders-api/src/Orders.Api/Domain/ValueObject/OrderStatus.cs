namespace Orders.Api.Domain.ValueObject;
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