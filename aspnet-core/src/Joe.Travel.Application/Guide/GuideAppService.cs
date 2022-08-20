using System;
using Joe.Travel.Models;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Joe.Travel
{
    [ApiExplorerSettings(GroupName = "Reference_Tables", IgnoreApi = false)]
    public class
    GuideAppService
    :
    CrudAppService<Guide,
        GuideDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateGuideDto
    >
    {
        public GuideAppService(IRepository<Guide, Guid> repository) :
            base(repository)
        {
        }
    }
}
