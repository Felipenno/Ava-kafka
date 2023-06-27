using System.ComponentModel;

namespace Orders.Api.Domain.ValueObject;

public enum PaymentType
{
    [Description("CreditCard")]
    CreditCard,
    [Description("DebitCard")]
    DebitCard,
    [Description("Paypal")]
    Paypal,
    [Description("GooglePay")]
    GooglePay,
    [Description("ApplePay")]
    ApplePay
}
