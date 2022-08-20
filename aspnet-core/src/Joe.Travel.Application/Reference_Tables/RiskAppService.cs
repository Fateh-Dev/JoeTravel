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
    RiskAppService
    :
    CrudAppService<Risk,
        RiskDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateRiskDto
    >
    {
        public RiskAppService(IRepository<Risk, Guid> repository) :
            base(repository)
        {
        }
    }
}
