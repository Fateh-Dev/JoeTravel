using System;
using System.ComponentModel.DataAnnotations;

namespace Joe.Travel
{
    public class CreateUpdateTripDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Difficulty Difficulty { get; set; }

        public int Duration { get; set; }

        public TripSize TripSize { get; set; }

        public DurationUnit DurationUnit { get; set; }

        public Guid GuideId { get; set; }

        public string[] ActivityNames { get; set; }

        public string[] RiskNames { get; set; }

        public string[] IncludedStuffNames { get; set; }

        public string[] LogingNames { get; set; }

        public string[] NotAllowedStuffNames { get; set; }

        public string[] NotSuitableForNames { get; set; }

        public string[] RequiredStuffNames { get; set; }
    }
}
