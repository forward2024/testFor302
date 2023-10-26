using TestFor302.Data;

namespace TestFor302.Service.ClientService
{
    public class ServiceClient : IClient
    {
        private readonly EntityDbContext context;

        public event Action Update;

        public ServiceClient(EntityDbContext context)
        {
            this.context = context;
            GetClients();
        }

        public List<Client> Clients { get; set; }

        private async Task GetClients()
        {
            Clients = await context.Clients.ToListAsync();
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
            var newClient = await context.Clients.FindAsync(client.Id);

            if (newClient != null)
            {
                context.Entry(newClient).CurrentValues.SetValues(client);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Клієнт не знайдений в базі даних.");
            }
            await GetClients();
        }
    }
}
