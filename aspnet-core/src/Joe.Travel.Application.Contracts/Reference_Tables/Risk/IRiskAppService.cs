using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Joe.Travel
{
    public interface
    IRiskAppService
    :
    ICrudAppService<//Defines CRUD methods
        RiskDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateRiskDto
    > //Used to create/update a book
    { }
}
