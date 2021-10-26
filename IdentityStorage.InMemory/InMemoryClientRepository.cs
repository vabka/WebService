using System.Collections.Concurrent;
using IdentityStorage.Persisted;

namespace IdentityStorage.InMemory;

public class InMemoryClientRepository : IClientRepository
{
    private readonly ConcurrentDictionary<string, Client> _clients = new();


    public Task<Client> GetClientById(string clientId) =>
        _clients.TryGetValue(clientId, out var client)
            ? Task.FromResult(client)
            : Task.FromException<Client>(new ClientNotFoundException(clientId));

    public Task<Client> CreateClient(ClientRegistrationData data)
    {
        string id;
        do
        {
            id = Guid.NewGuid().ToString();
        } while (!_clients.TryAdd(id, new Client(id, data.Name, data.Description, data.Type, data.ClientRedirectionUri)));

        return Task.FromResult(_clients[id]);
    }

    public Task<Client[]> GetAllClients() =>
        Task.FromResult(_clients.Values.ToArray());
}