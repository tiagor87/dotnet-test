namespace DotNet.Test.Api.Shared.Commands;

public interface IHandler<TCommand, TResponse>
{
    ValueTask<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
}