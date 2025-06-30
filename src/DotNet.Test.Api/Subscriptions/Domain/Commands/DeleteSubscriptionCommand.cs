using DotNet.Test.Api.Shared.Commands;

namespace DotNet.Test.Api.Subscriptions.Domain.Commands;

public record DeleteSubscriptionCommand(string Id);

public interface IDeleteSubscriptionHandler : IHandler<DeleteSubscriptionCommand, bool>;

