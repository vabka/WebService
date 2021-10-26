using System.Text.Json.Serialization;
using IdentityService.Endpoints;
using IdentityStorage.InMemory;
using IdentityStorage.Persisted.Clients;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IClientRepository, InMemoryClientRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(o =>
    o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
var app = builder.Build();
app.MapSwagger();
app.UseSwaggerUI();

app.MapClientEndpoints();

app.Run();