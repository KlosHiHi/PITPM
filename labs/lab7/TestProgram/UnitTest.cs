using FluentAssertions;
using Moq;
using OrderProcessing.Models;

namespace TestProgram
{
    public class UnitTest(RepositiryFixture fixture) : IClassFixture<RepositiryFixture>
    {
        private readonly RepositiryFixture _fixture = fixture;

        [Fact]
        public async Task CreateOrderAsync_WithCorrectCustomerId_ReturnOrder()
        {
            Order order = await _fixture.orderService.CreateOrderAsync(_fixture.CustomerId, 10.5M);

            _fixture.mockOrdersRepository.Verify(o => o.AddAsync(order), Times.Once());

            order.CustomerId.Should().Be(_fixture.CustomerId);
            order.TotalAmount.Should().Be(10.5M);
        }

        [Fact]
        public async Task CreateOrderAsync_WithUncorrectCustomerId_ThrowsException()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _fixture.orderService.CreateOrderAsync(Guid.NewGuid(), 10.5M);
            });
        }

        [Fact]
        public async Task ConfirmPaymentAsync_WithCorrectOrderId_MethonRunning()
        {
            await _fixture.orderService.ConfirmPaymentAsync(_fixture.Order.Id);

            _fixture.mockOrdersRepository.Verify(m => m.UpdateAsync(_fixture.Order), Times.AtLeast(1));

            var actual = await _fixture.mockOrdersRepository.Object.GetByIdAsync(_fixture.Order.Id);

            Assert.Equal(OrderStatus.Paid, actual?.Status);
        }

        [Fact]
        public async Task ConfirmPaymentAsync_WithUncorrectOrderId_ThrowsException()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _fixture.orderService.ConfirmPaymentAsync(Guid.NewGuid());
            });
        }

        [Fact]
        public async Task CancelOrderAsync_WithCorrectOrderId_MethodsRunning()
        {
            await _fixture.orderService.CancelOrderAsync(_fixture.Order.Id);

            //_fixture.mockMessageBus.Verify(m => m.PublishAsync("order.cancelled", new { _fixture.Order.Id }), Times.Once);
            _fixture.mockOrdersRepository.Verify(m => m.UpdateAsync(_fixture.Order), Times.AtLeast(1));

            var actual = await _fixture.mockOrdersRepository.Object.GetByIdAsync(_fixture.Order.Id);

            Assert.Equal(OrderStatus.Cancelled, actual?.Status);
        }

        [Fact]
        public async Task CancelOrderAsync_WithUncorrectOrderId_ThrowsException()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _fixture.orderService.CancelOrderAsync(Guid.NewGuid());
            });
        }

        [Fact]
        public async Task ShipOrderAsync_WithCorrectOrderId_MethodsRunning()
        {
            await _fixture.orderService.ConfirmPaymentAsync(_fixture.Order.Id);
            await _fixture.orderService.ShipOrderAsync(_fixture.Order.Id);

            _fixture.mockOrdersRepository.Verify(m => m.UpdateAsync(_fixture.Order), Times.AtLeast(1));

            var actual = await _fixture.mockOrdersRepository.Object.GetByIdAsync(_fixture.Order.Id);

            Assert.Equal(OrderStatus.Shipped, actual?.Status);
        }

        [Fact]
        public async Task ShipOrderAsync_WithUncorrectOrderId_ThrowsException()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _fixture.orderService.ShipOrderAsync(Guid.NewGuid());
            });
        }

        [Fact]
        public async Task ShipOrderAsync_WithUnpaidOrderId_ThrowsException()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _fixture.orderService.ShipOrderAsync(_fixture.Order.Id);
            });
        }
    }
}