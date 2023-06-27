using System.ComponentModel;

namespace Orders.Email.Domain.ValueObjects;
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