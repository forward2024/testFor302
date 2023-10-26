using TestFor302.Data;

namespace TestFor302.Service.ProductService
{
    public class ServiceProduct : IProduct
    {
        private readonly DbContextOptions<EntityDbContext> options;
        private readonly EntityDbContext context;

        public event Action Update;

        public ServiceProduct(DbContextOptions<EntityDbContext> options, EntityDbContext context)
        {
            this.options = options;
            this.context = context;
            GetProducts();
        }

        public List<Product> Products { get; set; } = new List<Product>();

        private async Task GetProducts()
        {
            using (var context = new EntityDbContext(options))
            {
                Products = await context.Products.ToListAsync();
            }
            Update?.Invoke();
        }

        public async Task CreateProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            await GetProducts();
        }

        public async Task DeleteProduct(int id)
        {
            context.Products.Remove(await context.Products.FindAsync(id));
            await context.SaveChangesAsync();
            await GetProducts();
        }
    }
}
