using Volo.Abp.Modularity;

namespace Joe.Travel;

[DependsOn(
    typeof(TravelApplicationModule),
    typeof(TravelDomainTestModule)
    )]
public class TravelApplicationTestModule : AbpModule
{

}
