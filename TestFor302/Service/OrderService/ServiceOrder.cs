using TestFor302.Data;

namespace TestFor302.Service.OrderService
{
    public class ServiceOrder : IOrder
    {
        private readonly DbContextOptions<EntityDbContext> options;
        private readonly EntityDbContext context;

        public event Action Update;

        public ServiceOrder(EntityDbContext context, DbContextOptions<EntityDbContext> options)
        {
            this.options = options;
            this.context = context;
            GetOrders();
        }

        public List<Order> Orders {  get; set; }


        private async Task GetOrders()
        {
            using (var context = new EntityDbContext(options))
            {
                Orders = await context.Orders.ToListAsync();
            }
            Update?.Invoke();
        }

        public async Task CreateOrder(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            GetOrders();
        }
    }
}
