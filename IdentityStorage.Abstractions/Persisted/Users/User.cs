namespace IdentityStorage.Persisted.Users;

/// <summary>
/// User entity
/// </summary>
/// <param name="Name">Unique name of user</param>
/// <param name="Secret">Secret string eg password hash</param>
public record User(string Name, byte[] Secret);