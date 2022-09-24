using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class TripGetListInput : PagedAndSortedResultRequestDto
    {
        public string Title { get; set; }
    }

}
