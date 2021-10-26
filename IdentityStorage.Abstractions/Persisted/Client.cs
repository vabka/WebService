using Ardalis.GuardClauses;

namespace IdentityStorage.Persisted;

/// <summary>
/// Client is an actor that want to access protected resource
/// </summary>
/// <param name="Id">Unique string to identify client</param>
/// <param name="Name">Name</param>
/// <param name="Description">Description</param>
/// <param name="Type">Client type by it's capability to store credentials</param>
/// <param name="ClientRedirectionUri">Uri that authorization server should redirect client on</param>
public record Client(
    string Id,
    string Name,
    string Description,
    ClientType Type,
    Uri[] ClientRedirectionUri);

/// <summary>
/// Data needed to register new client
/// </summary>
public record ClientRegistrationData
{
    public string Name { get; }
    public string Description { get; }
    public ClientType Type { get; }
    public Uri[] ClientRedirectionUri { get; }
    
    public ClientRegistrationData(
        string name,
        string description,
        ClientType type,
        Uri[] clientRedirectionUri)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        Description = Guard.Against.Null(description, nameof(description)).Trim();
        Type = Guard.Against.OutOfRange(type, nameof(type));
        ClientRedirectionUri = Guard.Against.NullOrEmpty(clientRedirectionUri, nameof(clientRedirectionUri)).ToArray();
    }
};