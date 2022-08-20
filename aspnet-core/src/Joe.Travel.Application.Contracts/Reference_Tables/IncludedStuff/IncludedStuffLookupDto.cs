using System; 
using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class IncludedStuffLookupDto : EntityDto<Guid>
    {
        public string DescriptionFr { get; set; }
    }
}
