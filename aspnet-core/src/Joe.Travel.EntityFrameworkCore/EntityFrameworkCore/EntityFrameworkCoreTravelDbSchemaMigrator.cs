using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Joe.Travel.Data;
using Volo.Abp.DependencyInjection;

namespace Joe.Travel.EntityFrameworkCore;

public class EntityFrameworkCoreTravelDbSchemaMigrator
    : ITravelDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreTravelDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the TravelDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<TravelDbContext>()
            .Database
            .MigrateAsync();
    }
}
