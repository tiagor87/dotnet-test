using DotNet.Test.Api;

using TheNoobs.DependencyInjection.Extensions.Modules;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Configuration.AddEnvironmentVariables("SUBSCRIPTION_API_");

builder.Services.AddInjections(builder.Configuration, AssemblyMarker.Self);

var app = builder.Build();

app.UseInjections(AssemblyMarker.Self);

await app.RunAsync();

app.MapPost("/subscriptions", DotNet.Test.Api.Subscriptions.App.Endpoints.CreateEndpoint.HandleAsync);
app.MapGet("/subscriptions/{id}", DotNet.Test.Api.Subscriptions.App.Endpoints.FindByIdEndpoint.HandleAsync);
app.MapPut("/subscriptions/{id}", DotNet.Test.Api.Subscriptions.App.Endpoints.UpdateEndpoint.HandleAsync);
app.MapDelete("/subscriptions/{id}", DotNet.Test.Api.Subscriptions.App.Endpoints.DeleteEndpoint.HandleAsync);

