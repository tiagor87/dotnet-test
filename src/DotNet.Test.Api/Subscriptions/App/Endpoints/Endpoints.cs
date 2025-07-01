using TheNoobs.DependencyInjection.Extensions.Modules.Abstractions;

namespace DotNet.Test.Api.Subscriptions.App.Endpoints;

public class Endpoints : IApplicationModuleSetup
{
    public void Setup(IApplicationBuilder appBuilder)
    {
        if (appBuilder is not IEndpointRouteBuilder endpointRouteBuilder)
        {
            return;
        }

        endpointRouteBuilder.MapGet("/subscriptions", FindAllEndpoint.HandleAsync);
        endpointRouteBuilder.MapPost("/subscriptions", CreateEndpoint.HandleAsync);
        endpointRouteBuilder.MapGet("/subscriptions/{id}", FindByIdEndpoint.HandleAsync);
        endpointRouteBuilder.MapPut("/subscriptions/{id}", UpdateEndpoint.HandleAsync);
        endpointRouteBuilder.MapDelete("/subscriptions/{id}", DeleteEndpoint.HandleAsync);
    }
}