using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class Lookups : EntityDto<Guid>
    {
        public List<LogingLookupDto> Logings { get; set; }

        public List<NotAllowedStuffLookupDto> NotAllowedStuffs { get; set; }

        public List<ActivityLookupDto> Activities { get; set; }

        public List<RiskLookupDto> Risks { get; set; }

        public List<RequiredStuffLookupDto> RequiredStuffs { get; set; }

        public List<IncludedStuffLookupDto> IncludedStuffs { get; set; }

        public List<NotSuitableForLookupDto> NotSuitableFors { get; set; }
        public List<GuideLookupDto> Guides { get; set; }
    }
}
