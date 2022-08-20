using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Joe.Travel;

[Dependency(ReplaceServices = true)]
public class TravelBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Travel";
}
