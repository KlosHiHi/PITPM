namespace Lection.DIP
{
    public class StripePaymentProcessor
    {
        public void Charge(decimal amount)
        {
            //Do Something
        }
    }

    public class OrderProcessor
    {
        public void Process(Order order)
        {
            var payment = new StripePaymentProcessor();
            payment.Charge(order.Amount);
        }
    }
}
