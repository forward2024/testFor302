using TestFor302.Data;

namespace TestFor302.Service.ProductService
{
    public class ServiceProduct : IProduct
    {
        private readonly EntityDbContext context;

        public event Action Update;

        public ServiceProduct(EntityDbContext context)
        {
            this.context = context;
            GetProducts();
        }

        public List<Product> Products { get; set; }

        private async Task GetProducts()
        {
            Products = await context.Products.ToListAsync();
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
