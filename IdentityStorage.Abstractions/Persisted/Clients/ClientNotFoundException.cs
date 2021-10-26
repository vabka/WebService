using System.Runtime.Serialization;

namespace IdentityStorage.Persisted.Clients;

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