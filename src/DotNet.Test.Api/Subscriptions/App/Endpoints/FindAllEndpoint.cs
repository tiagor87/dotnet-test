using DotNet.Test.Api.Subscriptions.Domain.Commands;

using Microsoft.AspNetCore.Mvc;

namespace DotNet.Test.Api.Subscriptions.App.Endpoints;

public static class FindAllEndpoint
{
    public static async ValueTask<IResult> HandleAsync(
        [FromServices] IFindAllHandler handler,
        [AsParameters] FindAllDto findAll,
        CancellationToken cancellationToken)
    {
        var subscriptions = await handler.HandleAsync(findAll, cancellationToken);
        return Results.Ok(subscriptions);
    }
    
    public class FindAllDto : IFindAll
    {
        [FromQuery] public int? PageSize { get; init; } = 10;
        [FromQuery] public int? Page { get; init; } = 1;
    }
}