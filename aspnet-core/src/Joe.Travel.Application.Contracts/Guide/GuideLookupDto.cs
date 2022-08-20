using System;
using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class GuideLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
