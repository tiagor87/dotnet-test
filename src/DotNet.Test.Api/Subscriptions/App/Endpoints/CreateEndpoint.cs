using DotNet.Test.Api.Subscriptions.Domain.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace DotNet.Test.Api.Subscriptions.App.Endpoints;

public static class CreateEndpoint
{
    public static async Task<IResult> HandleAsync(
        [FromBody] CreateSubscriptionCommand command,
        [FromServices] Shared.Commands.IHandler<CreateSubscriptionCommand, Subscription> handler)
    {
        var result = await handler.HandleAsync(command, CancellationToken.None);
        return Results.Created($"/subscriptions/{result.Id}", result);
    }
}

