using DotNet.Test.Api;

using TheNoobs.DependencyInjection.Extensions.Modules;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Configuration.AddEnvironmentVariables("SUBSCRIPTION_API_");

builder.Services.AddInjections(builder.Configuration, AssemblyMarker.Self);

var app = builder.Build();

app.UseInjections(AssemblyMarker.Self);

await app.RunAsync();