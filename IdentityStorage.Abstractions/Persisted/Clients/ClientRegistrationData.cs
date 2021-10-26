namespace IdentityStorage.Persisted.Clients;

/// <summary>
/// Data needed to register new client
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Type"></param>
/// <param name="ClientRedirectionUri"></param>
public record ClientRegistrationData(
    string Name,
    string Description,
    ClientType Type,
    Uri[] ClientRedirectionUri);