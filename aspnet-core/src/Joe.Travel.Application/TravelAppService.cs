using System;
using System.Collections.Generic;
using System.Text;
using Joe.Travel.Localization;
using Volo.Abp.Application.Services;

namespace Joe.Travel;

/* Inherit your application services from this class.
 */
public abstract class TravelAppService : ApplicationService
{
    protected TravelAppService()
    {
        LocalizationResource = typeof(TravelResource);
    }
}
