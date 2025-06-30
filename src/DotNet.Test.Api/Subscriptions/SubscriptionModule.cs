using DotNet.Test.Api.Subscriptions.Domain.Commands;
using DotNet.Test.Api.Subscriptions.Domain.Repositories;
using DotNet.Test.Api.Subscriptions.Infra.Repositories;

using TheNoobs.DependencyInjection.Extensions.Modules.Abstractions;

namespace DotNet.Test.Api.Subscriptions;

public class SubscriptionModule : IServiceModuleSetup
{
    public void Setup(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        services.AddScoped<IFindAllHandler, FindAllHandler>();
        services.AddScoped<ICreateSubscriptionHandler, CreateSubscriptionHandler>();
        services.AddScoped<IFindByIdHandler, FindByIdHandler>();
        services.AddScoped<IUpdateSubscriptionHandler, UpdateSubscriptionHandler>();
        services.AddScoped<IDeleteSubscriptionHandler, DeleteSubscriptionHandler>();
    }
}
