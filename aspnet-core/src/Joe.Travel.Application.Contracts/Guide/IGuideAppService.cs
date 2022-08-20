using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Joe.Travel
{
    public interface
    IGuideAppService
    :
    ICrudAppService<GuideDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateGuideDto
    >
    { }
}
