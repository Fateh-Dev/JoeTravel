using System;
using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class GuideDto : EntityDto<Guid>
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        
    }
}
