using FluentAssertions;
using Moq;
using OrderProcessing.Interfaces;
using OrderProcessing.Models;
using OrderProcessing.Services;

namespace TestProgram
{
    public class RepositiryFixture : IDisposable
    {
        public Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
        public Mock<IMessageBus> mockMessageBus = new Mock<IMessageBus>();
        public Mock<IOrderRepository> mockOrdersRepository = new Mock<IOrderRepository>();

        public Guid OrderId = Guid.NewGuid();
        public Guid CustomerId = Guid.NewGuid();

        public RepositiryFixture()
        {
            mockCustomerRepository.Setup(c => c.GetByIdAsync(CustomerId)).ReturnsAsync(new Customer { Id = CustomerId });
            mockCustomerRepository.Setup(c => c.GetByIdAsync(It.IsNotIn(CustomerId))).ReturnsAsync(() => null);

            mockOrdersRepository.Setup(o => o.GetByIdAsync(OrderId)).ReturnsAsync(new Order() { Id = OrderId });
            mockOrdersRepository.Setup(o => o.GetByIdAsync(It.IsNotIn(OrderId))).ReturnsAsync(() => null);
        }

        public void Dispose() { }
    }

    public class UnitTest(RepositiryFixture fixture) : IClassFixture<RepositiryFixture>
    {
        private readonly RepositiryFixture _fixture = fixture;

        [Fact]
        public async Task CreateOrderAsync_WithCorrectCustomerId_ReturnOrder()
        {
            OrderService orderService = new(
                _fixture.mockOrdersRepository.Object,
                _fixture.mockCustomerRepository.Object,
                _fixture.mockMessageBus.Object);

            Order order = await orderService.CreateOrderAsync(_fixture.CustomerId, 10.5M);

            _fixture.mockOrdersRepository.Verify(o => o.AddAsync(order), Times.Once());
            _fixture.mockMessageBus.Verify(m => m.PublishAsync("order.created", new { order.Id, order.CustomerId }), Times.Once());

            order.CustomerId.Should().Be(_fixture.CustomerId);
            order.TotalAmount.Should().Be(10.5M);
        }

        [Fact]
        public async Task CreateOrderAsync_WithUncorrectCustomerId_ThrowsException()
        {
            OrderService orderService = new(
                _fixture.mockOrdersRepository.Object,
                _fixture.mockCustomerRepository.Object,
                _fixture.mockMessageBus.Object);

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await orderService.CreateOrderAsync(Guid.NewGuid(), 10.5M);
            });
        }
    }
}