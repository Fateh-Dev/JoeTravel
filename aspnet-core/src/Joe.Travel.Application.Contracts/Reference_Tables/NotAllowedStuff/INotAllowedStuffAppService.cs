using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Joe.Travel
{
    public interface
    INotAllowedStuffAppService
    :
    ICrudAppService<//Defines CRUD methods
        NotAllowedStuffDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateNotAllowedStuffDto
    > //Used to create/update a book
    { }
}
