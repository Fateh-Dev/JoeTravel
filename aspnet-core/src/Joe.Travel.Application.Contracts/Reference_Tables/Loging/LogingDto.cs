using System;
using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class LogingDto : EntityDto<Guid>
    {
        public string DescriptionFr { get; set; }

        public string DescriptionAr { get; set; }
    }
}
