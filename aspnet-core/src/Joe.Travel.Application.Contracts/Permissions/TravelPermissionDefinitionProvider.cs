using Joe.Travel.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Joe.Travel.Permissions;

public class TravelPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TravelPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(TravelPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TravelResource>(name);
    }
}
