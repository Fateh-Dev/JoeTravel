using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Joe.Travel
{
    public interface
    IIncludedStuffAppService
    :
    ICrudAppService<//Defines CRUD methods
        IncludedStuffDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateIncludedStuffDto
    > //Used to create/update a book
    { }
}
