using System.Threading.Tasks;

namespace Joe.Travel.Data;

public interface ITravelDbSchemaMigrator
{
    Task MigrateAsync();
}
