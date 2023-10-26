namespace TestFor302.Service.OrderService
{
    public interface IOrder
    {
        Task CreateOrder(Order order);
        Task GetOrders();
    }
}
