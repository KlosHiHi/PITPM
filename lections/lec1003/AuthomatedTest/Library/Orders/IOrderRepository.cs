namespace Library.Orders
{
    public interface IOrderRepository
    {
        bool TrySaveOrder(Order order);
    }
}
