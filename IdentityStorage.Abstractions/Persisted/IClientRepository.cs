using System.Runtime.Serialization;

namespace IdentityStorage.Persisted;

public interface IClientRepository
{
    /// <summary>
    /// Get client by it's unique id
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    public Task<Client> GetClientById(string clientId);
    
    /// <summary>
    /// Register new client
    /// </summary>
    /// <param name="data">data of new client</param>
    /// <returns>newly registered client</returns>
    public Task<Client> CreateClient(ClientRegistrationData data);

    /// <summary>
    /// Get all clients
    /// </summary>
    /// <returns></returns>
    public Task<Client[]> GetAllClients();
}

public class ClientNotFoundException : Exception
{
    public ClientNotFoundException(string clientId)
    {
        ClientId = clientId;
    }

    protected ClientNotFoundException(SerializationInfo info, StreamingContext context, string clientId) : base(info, context)
    {
        ClientId = clientId;
    }

    public ClientNotFoundException(string? message, string clientId) : base(message)
    {
        ClientId = clientId;
    }

    public ClientNotFoundException(string? message, Exception? innerException, string clientId) : base(message, innerException)
    {
        ClientId = clientId;
    }

    public string ClientId { get; }
}