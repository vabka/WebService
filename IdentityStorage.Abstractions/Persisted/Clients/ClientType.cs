namespace IdentityStorage.Persisted.Clients;

/// <summary>
/// Client type discriminated by it's capability to store credentials
/// </summary>
public enum ClientType
{
    /// <summary>
    /// Confidential client is a client that can safely store client credentials. eg server-side application
    /// </summary>
    Confidential,
    /// <summary>
    /// Public client is a client that cannot safely store client credentials. eg SPA or Mobile app
    /// </summary>
    Public,
}