using System.Collections.Concurrent;
using IdentityStorage.Persisted.Clients;

namespace IdentityStorage.InMemory;

public class InMemoryClientRepository : IClientRepository
{
    private readonly ConcurrentDictionary<string, Client> _clients = new();


    public Task<Client> GetClientById(string clientId, CancellationToken cancellationToken = default) =>
        _clients.TryGetValue(clientId, out var client)
            ? Task.FromResult(client)
            : Task.FromException<Client>(new ClientNotFoundException(clientId));

    public Task<Client> CreateClient(ClientRegistrationData data, CancellationToken cancellationToken = default)
    {
        string id;
        do
        {
            id = Guid.NewGuid().ToString();
        } while (!_clients.TryAdd(id, new Client(id, data.Name, data.Description, data.Type, data.ClientRedirectionUri)));

        return Task.FromResult(_clients[id]);
    }

    public Task<Client[]> GetAllClients(CancellationToken cancellationToken = default) =>
        Task.FromResult(_clients.Values.ToArray());

    public Task DeleteClient(string clientId, CancellationToken cancellationToken = default) =>
        _clients.TryRemove(clientId, out _)
            ? Task.CompletedTask
            : Task.FromException(new ClientNotFoundException(clientId));
}