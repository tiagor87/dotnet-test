using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Entities;

namespace DotNet.Test.Api.Subscriptions.Domain.Commands;

public record FindByIdCommand(string Id);

public interface IFindByIdHandler : IHandler<FindByIdCommand, ISubscriptionView>;

