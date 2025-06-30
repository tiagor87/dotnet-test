using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Commands;

using Microsoft.AspNetCore.Mvc;

namespace DotNet.Test.Api.Subscriptions.App.Endpoints;

public static class DeleteEndpoint
{
    public static async Task<IResult> HandleAsync(
        [FromRoute] string id,
        [FromServices] Shared.Commands.IHandler<DeleteSubscriptionCommand, bool> handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.HandleAsync(new DeleteSubscriptionCommand(id), cancellationToken);
        return result ? Results.NoContent() : Results.NotFound();
    }
}

