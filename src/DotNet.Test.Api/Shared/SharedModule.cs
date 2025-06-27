using DotNet.Test.Api.Shared.Repositories;

using EntityFramework.Exceptions.PostgreSQL;

using Microsoft.EntityFrameworkCore;

using TheNoobs.DependencyInjection.Extensions.Modules.Abstractions;

namespace DotNet.Test.Api.Shared;

public class SharedModule : IServiceModuleSetup
{
    public void Setup(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SubscriptionDbContext>(options =>
        {
            options
                .UseNpgsql(configuration.GetConnectionString("Postgres"), builder =>
                {
                    builder.EnableRetryOnFailure();
                })
                .UseExceptionProcessor()
                .UseCamelCaseNamingConvention()
                .UseLazyLoadingProxies();
        });
        
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<SubscriptionDbContext>());
    }
}