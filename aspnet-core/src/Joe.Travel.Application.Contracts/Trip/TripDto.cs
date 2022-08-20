using System;
using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class TripDto : EntityDto<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string GuideName { get; set; }

        public double Rating { get; set; }

        public string Duration { get; set; }

        public byte[] Thumbnail { get; set; }

        public string TripSize { get; set; } 

        public string Difficulty { get; set; }

        public string[] ActivityNames { get; set; }

        public string[] RiskNames { get; set; }

        public string[] IncludedStuffNames { get; set; }

        public string[] LogingNames { get; set; }

        public string[] NotAllowedStuffNames { get; set; }

        public string[] NotSuitableForNames { get; set; }

        public string[] RequiredStuffNames { get; set; }
    }
}
