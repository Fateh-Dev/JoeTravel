using Volo.Abp.Settings;

namespace Joe.Travel.Settings;

public class TravelSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TravelSettings.MySetting1));
    }
}
