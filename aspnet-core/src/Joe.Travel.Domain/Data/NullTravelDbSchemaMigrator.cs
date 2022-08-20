using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Joe.Travel.Data;

/* This is used if database provider does't define
 * ITravelDbSchemaMigrator implementation.
 */
public class NullTravelDbSchemaMigrator : ITravelDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
