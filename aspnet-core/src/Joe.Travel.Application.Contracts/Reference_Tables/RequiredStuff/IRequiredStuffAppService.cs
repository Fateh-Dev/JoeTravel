using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Joe.Travel
{
    public interface
    IRequiredStuffAppService
    :
    ICrudAppService<//Defines CRUD methods
        RequiredStuffDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateRequiredStuffDto
    > //Used to create/update a book
    { }
}
