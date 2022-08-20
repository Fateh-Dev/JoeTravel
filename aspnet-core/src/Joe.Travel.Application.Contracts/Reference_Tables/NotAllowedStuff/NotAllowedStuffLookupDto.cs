using System; 
using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class NotAllowedStuffLookupDto : EntityDto<Guid>
    {
        public string DescriptionFr { get; set; }
    }
}
