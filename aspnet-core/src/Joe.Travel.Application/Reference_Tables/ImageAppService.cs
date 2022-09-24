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
    ImageAppService
    :
    CrudAppService<Image,
        ImageDto,
        Guid,
        PagedAndSortedResultRequestDto,
        ImageDto
    >
    {
        public ImageAppService(IRepository<Image, Guid> repository) :
            base(repository)
        {
        }
    }
}
