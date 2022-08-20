using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Joe.Travel
{
    public interface
    ILogingAppService
    :
    ICrudAppService<//Defines CRUD methods
        LogingDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateLogingDto
    > //Used to create/update a book
    { }
}
