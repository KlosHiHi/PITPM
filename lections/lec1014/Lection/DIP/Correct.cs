using Lection.DIP;

namespace Lection.DIP
{
    public interface IPaymentProcessor { void Charge(decimal amount); }

    public class StripePaymentProcessor1 : IPaymentProcessor
    {
        public void Charge(decimal amount)
        {
            //Do Something
        }
    }
}

public class OrderProcessor1
{
    private readonly IPaymentProcessor _processor;

    public OrderProcessor1(IPaymentProcessor processor)
    {
        _processor = processor;
    }

    public void Process(Order order)
    {
        var payment = new StripePaymentProcessor1();
        payment.Charge(order.Amount);
    }
}
}
