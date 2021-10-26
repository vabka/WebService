namespace IdentityStorage.Persisted.Clients;

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