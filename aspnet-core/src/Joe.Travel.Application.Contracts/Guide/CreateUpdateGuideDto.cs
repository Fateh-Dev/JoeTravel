using System.ComponentModel.DataAnnotations;

namespace Joe.Travel
{
    public class CreateUpdateGuideDto
    {
        [Required]
        [MaxLength(128)]
        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}
