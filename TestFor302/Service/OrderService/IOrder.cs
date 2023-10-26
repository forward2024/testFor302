namespace TestFor302.Service.OrderService
{
    public interface IOrder
    {
        event Action Update;
        List<Order> Orders { get; }
        Task CreateOrder(Order order);
    }
}
