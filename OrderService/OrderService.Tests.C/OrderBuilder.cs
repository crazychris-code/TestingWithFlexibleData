using System.Collections.Generic;
using System.Linq;

namespace OrderService.Tests.C
{
    public class OrderBuilder
    {
        private List<Order> _orders = new List<Order>();

        public OrderBuilder WithSingle()
        {
            _orders.Add(new Order());
            return this;
        }

        public OrderBuilder WithStatusInProgress()
        {
            _orders.Last().StartProcessing();
            return this;
        }

        public List<Order> Build()
        {
            return _orders;
        }
    }
}
