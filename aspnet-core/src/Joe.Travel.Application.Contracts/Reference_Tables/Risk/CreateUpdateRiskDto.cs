using System;
using System.ComponentModel.DataAnnotations;

namespace Joe.Travel
{
    public class CreateUpdateRiskDto
    {
        [Required]
        public string DescriptionFr { get; set; }

        public string DescriptionAr { get; set; }
    }
}
