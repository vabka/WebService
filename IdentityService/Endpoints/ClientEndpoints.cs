using IdentityStorage.Persisted.Clients;
using static IdentityService.Endpoints.Routes.Api.V1.Clients;

namespace IdentityService.Endpoints;

public static class ClientEndpointsExtensions
{
    public static WebApplication MapClientEndpoints(this WebApplication app)
    {
        app.MapGet(GetAll, async (IClientRepository repo) => await repo.GetAllClients())
            .Produces<Client[]>(200);

        app.MapGet(GetById, async (string id, IClientRepository repo) =>
            {
                try
                {
                    return Results.Ok(await repo.GetClientById(id));
                }
                catch (ClientNotFoundException)
                {
                    return Results.NotFound();
                }
            })
            .Produces<Client>(200)
            .Produces(404);

        app.MapPost(CreateNew, async (ClientRegistrationData registrationData, IClientRepository repo) =>
                await repo.CreateClient(registrationData))
            .Produces(200);

        app.MapDelete(DeleteById, async (string id, IClientRepository repo) =>
            {
                try
                {
                    await repo.DeleteClient(id);
                    return Results.Ok();
                }
                catch (ClientNotFoundException)
                {
                    return Results.NotFound();
                }
            })
            .Produces(200)
            .Produces(404);

        return app;
    }
}