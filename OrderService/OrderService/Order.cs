namespace OrderService
{
    public class Order
    {
        public OrderStatus Status { get; set; }

        public void Cancel ()
        {
            Status = OrderStatus.Canceled;
        }

        public void StartProcessing()
        {
            Status = OrderStatus.InProgress;
        }
    }

    public enum OrderStatus
    {
        InProgress,
        Canceled
    }
}
