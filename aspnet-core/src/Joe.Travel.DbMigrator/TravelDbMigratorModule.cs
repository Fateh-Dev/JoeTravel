using Joe.Travel.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Joe.Travel.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TravelEntityFrameworkCoreModule),
    typeof(TravelApplicationContractsModule)
    )]
public class TravelDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
