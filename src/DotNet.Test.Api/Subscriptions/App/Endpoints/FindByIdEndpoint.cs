using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace DotNet.Test.Api.Subscriptions.App.Endpoints;

public static class FindByIdEndpoint
{
    public static async Task<IResult> HandleAsync(
        [FromRoute] string id,
        [FromServices] Shared.Commands.IHandler<FindByIdCommand, ISubscriptionView> handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.HandleAsync(new FindByIdCommand(id), cancellationToken);
        return result is null ? Results.NotFound() : Results.Ok(result);
    }
}

