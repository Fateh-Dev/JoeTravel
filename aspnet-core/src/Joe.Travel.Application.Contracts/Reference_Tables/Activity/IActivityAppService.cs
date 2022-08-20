using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Joe.Travel
{
    public interface
    IActivityAppService
    :
    ICrudAppService<//Defines CRUD methods
        ActivityDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateActivityDto
    > //Used to create/update a book
    { }
}
