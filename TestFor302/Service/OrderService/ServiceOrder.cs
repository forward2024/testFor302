using TestFor302.Data;
using TestFor302.Models;

namespace TestFor302.Service.OrderService
{
    public class ServiceOrder : IOrder
    {
        private readonly EntityDbContext context;

        public ServiceOrder(EntityDbContext context)
        {
            this.context = context;
        }


        public async Task CreateOrder(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }

        public Task GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
