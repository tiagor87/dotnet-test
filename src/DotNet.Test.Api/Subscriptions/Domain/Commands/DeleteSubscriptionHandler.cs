using DotNet.Test.Api.Shared.Commands;
using DotNet.Test.Api.Shared.Repositories;
using DotNet.Test.Api.Subscriptions.Domain.Repositories;

namespace DotNet.Test.Api.Subscriptions.Domain.Commands;

public class DeleteSubscriptionHandler : IDeleteSubscriptionHandler
{
    private readonly ISubscriptionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSubscriptionHandler(ISubscriptionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public bool Handle(DeleteSubscriptionCommand command)
    {
        throw new NotImplementedException();
    }


    public async ValueTask<bool> HandleAsync(DeleteSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var subscription = await _repository.FindByIdAsync(command.Id, cancellationToken);

        if (subscription is null)
        {
            return false;
        }

        await _repository.DeleteAsync(subscription, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}

