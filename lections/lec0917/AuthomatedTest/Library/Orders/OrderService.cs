namespace Library.Orders
{
    public class OrderService(IOrderRepository repository, IEventBus eventBus)
    {
        private IEventBus _eventBus = eventBus;
        private IOrderRepository _repository = repository;

        public void CreateOrder(int id, string name, string description)
        {
            var order = new Order(id, name, description);

            if (_repository.TrySaveOrder(order))
                _eventBus.Publish(order, "Заказ успешно создан");
            else
                _eventBus.Publish(order, "Не удалось сохранить заказ");
        }
    }
}
