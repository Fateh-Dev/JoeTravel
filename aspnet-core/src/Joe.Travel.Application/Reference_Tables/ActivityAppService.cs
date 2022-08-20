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
    ActivityAppService
    :
    CrudAppService<Activity,
        ActivityDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateActivityDto
    >
    {
        public ActivityAppService(IRepository<Activity, Guid> repository) :
            base(repository)
        {
        }
    }
}
