using FluentAssertions;
using System.Linq;
using Xunit;

namespace OrderService.Tests.C
{
    public class OrderTests
    {
        [Fact]
        public void CancelOrderTest()
        {
            //Arrange
            var order = new OrderBuilder()
                .WithSingle()
                .WithStatusInProgress()
                .Build()
                .First();

            //Act
            order.Cancel();

            //Assert
            order.Status.Should().Be(OrderStatus.Canceled);
        }
    }
}
