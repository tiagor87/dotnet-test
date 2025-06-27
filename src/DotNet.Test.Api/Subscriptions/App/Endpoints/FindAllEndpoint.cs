using DotNet.Test.Api.Subscriptions.Domain.Commands;

using Microsoft.AspNetCore.Mvc;

using TheNoobs.DependencyInjection.Extensions.Modules.Abstractions;

namespace DotNet.Test.Api.Subscriptions.App.Endpoints;

public class FindAllEndpoint : IApplicationModuleSetup
{
    private static async ValueTask<IResult> FindAllAsync(
        [FromServices] IFindAllHandler handler,
        [AsParameters] FindAllDto findAll,
        CancellationToken cancellationToken)
    {
        var subscriptions = await handler.HandleAsync(findAll, cancellationToken);
        return Results.Ok(subscriptions);
    }
    
    public void Setup(IApplicationBuilder appBuilder)
    {
        if (appBuilder is not IEndpointRouteBuilder endpointRouteBuilder)
        {
            return;
        }
        
        endpointRouteBuilder.MapGet("/subscriptions", FindAllAsync);
    }

    public class FindAllDto : IFindAll
    {
        [FromQuery]
        public int? PageSize { get; init; } = 10;
        [FromQuery]
        public int? Page { get; init; } = 1;
    }
}