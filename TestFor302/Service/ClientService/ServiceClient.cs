using TestFor302.Data;

namespace TestFor302.Service.ClientService
{
    public class ServiceClient : IClient
    {
        private readonly DbContextOptions<EntityDbContext> options;
        private readonly EntityDbContext context;

        public event Action Update;

        public ServiceClient(EntityDbContext context, DbContextOptions<EntityDbContext> options)
        {
            this.context = context;
            this.options = options;
            GetClients();
        }

        public List<Client> Clients { get; set; } = new List<Client>();

        public async Task GetClients()
        {
            using (var context1 = new EntityDbContext(options))
            {
                Clients = await context.Clients.ToListAsync();
            }
            Update?.Invoke();
        }

        public async Task CreateClient(Client client)
        {
            context.Clients.Add(client);
            await context.SaveChangesAsync();
            await GetClients();
        }

        public async Task DeleteClient(int id)
        {
            context.Clients.Remove(await context.Clients.FindAsync(id));
            await context.SaveChangesAsync();
            await GetClients();
        }

        public async Task EditClient(Client client)
        {
            context.Clients.Update(client);
            await context.SaveChangesAsync();
            await GetClients();
        }
    }
}
