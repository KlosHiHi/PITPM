using Library.Orders;
using Moq;

namespace UnitTest
{
    public class OrderServiceTests
    {
        private Mock<IEventBus> _mockEventBus;
        private Mock<IOrderRepository> _mockRepository;

        public OrderServiceTests()
        {
            _mockEventBus = new Mock<IEventBus>();
            _mockRepository = new Mock<IOrderRepository>();
            var order = new Order(1, "Test", "TestDescription");
            _mockRepository.Setup(x => x.TrySaveOrder(It.IsAny<Order>())).Returns(true);
            _mockRepository.Setup(x => x.TrySaveOrder(It.Is<Order>(x=>x.Id == 1 && x.Name == "Test" && x.Description == "TestDescription"))).Returns(false);
        }

        //[Fact]
        //public void CreateOrder_WithCorrectData_SendSuccessMessage()
        //{
        //    OrderService service = new OrderService(_mockRepository.Object, _mockEventBus.Object);

        //    service.CreateOrder(1, "Test", "TestDescription");
        //    var order = new Order(1, "Test", "TestDescription");

        //    _mockEventBus.Verify(x => x.Publish(It.IsAny<Order>(), "Заказ успешно созда"));
        //}
    }
}
