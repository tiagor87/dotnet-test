using DotNet.Test.Api.Subscriptions.Domain.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;

namespace DotNet.Test.Api.Shared.Commands;

public interface IHandler<TCommand, TResponse>
{
    ValueTask<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
}
