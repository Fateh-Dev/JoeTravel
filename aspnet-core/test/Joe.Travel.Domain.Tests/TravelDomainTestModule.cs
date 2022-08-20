using Joe.Travel.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Joe.Travel;

[DependsOn(
    typeof(TravelEntityFrameworkCoreTestModule)
    )]
public class TravelDomainTestModule : AbpModule
{

}
