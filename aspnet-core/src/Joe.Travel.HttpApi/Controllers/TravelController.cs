using Joe.Travel.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Joe.Travel.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TravelController : AbpControllerBase
{
    protected TravelController()
    {
        LocalizationResource = typeof(TravelResource);
    }
}
