namespace Library.Orders
{
    public interface IEventBus
    {
        void Publish(Order order, string message);
    }
}
