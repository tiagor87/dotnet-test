namespace DotNet.Test.Api.Shared.Repositories;

public interface IUnitOfWork
{
    ValueTask CompleteAsync(CancellationToken cancellationToken);
}