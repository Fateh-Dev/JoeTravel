using System;
using System.ComponentModel.DataAnnotations;

namespace Joe.Travel
{
    public class CreateUpdateNotAllowedStuffDto
    {
        [Required]
        public string DescriptionFr { get; set; }

        public string DescriptionAr { get; set; }
    }
}
