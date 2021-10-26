namespace IdentityStorage.Persisted.Clients;

public interface IClientRepository
{
    /// <summary>
    /// Get client by it's unique id
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<Client> GetClientById(string clientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Register new client
    /// </summary>
    /// <param name="data">data of new client</param>
    /// <param name="cancellationToken"></param>
    /// <returns>newly registered client</returns>
    public Task<Client> CreateClient(ClientRegistrationData data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all clients
    /// </summary>
    /// <returns></returns>
    public Task<Client[]> GetAllClients(CancellationToken cancellationToken = default);


    /// <summary>
    /// Delete client by id
    /// </summary>
    /// <param name="clientId">client id</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task DeleteClient(string clientId, CancellationToken cancellationToken = default);
}