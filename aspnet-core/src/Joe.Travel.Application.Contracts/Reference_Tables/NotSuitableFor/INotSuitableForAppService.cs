using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Joe.Travel
{
    public interface
    INotSuitableForAppService
    :
    ICrudAppService<//Defines CRUD methods
        NotSuitableForDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateNotSuitableForDto
    > //Used to create/update a book
    { }
}
