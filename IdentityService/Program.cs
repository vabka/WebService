using IdentityStorage.InMemory;
using IdentityStorage.Persisted;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IClientRepository, InMemoryClientRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapSwagger();
app.UseSwaggerUI();

app.MapGet("/api/v1/clients", async (IClientRepository repo) => await repo.GetAllClients());

app.MapGet("/api/v1/clients/{id}", async (string id, IClientRepository repo) =>
{
    try
    {
        return Results.Ok(await repo.GetClientById(id));
    }
    catch (ClientNotFoundException)
    {
        return Results.NotFound();
    }
});

app.MapPost("/api/v1/clients", async (ClientRegistrationData registrationData, IClientRepository repo) =>
        await repo.CreateClient(registrationData));

app.Run();