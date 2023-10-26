namespace TestFor302.Service.ProductService
{
    public interface IProduct
    {
        event Action Update;
        List<Product> Products { get; }
        Task CreateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
