namespace TestFor302.Service.ClientService
{
    public interface IClient
    {
        event Action Update;
        List<Client> Clients { get; }
        Task GetClients();
        Task CreateClient(Client client);
        Task EditClient(Client client);
        Task DeleteClient(int id);
    }
}
