using System;
using System.ComponentModel.DataAnnotations;

namespace Joe.Travel
{
    public class CreateUpdateLogingDto
    {
        [Required]
        public string DescriptionFr { get; set; }

        public string DescriptionAr { get; set; }
    }
}
