using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace DotNet.Test.Api.Subscriptions.App.Endpoints;

public static class UpdateEndpoint
{
    public static async Task<IResult> HandleAsync(
        [FromRoute] string id,
        [FromBody] UpdateSubscriptionCommand command,
        [FromServices] Shared.Commands.IHandler<UpdateSubscriptionCommand, Subscription> handler,
        CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return Results.BadRequest();
        }

        var result = await handler.HandleAsync(command, cancellationToken);
        return result is null ? Results.NotFound() : Results.Ok(result);
    }
}

