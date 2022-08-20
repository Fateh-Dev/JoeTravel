using System;
using Volo.Abp.Domain.Entities;

namespace Joe.Travel.Models
{
    public class Image : Entity<Guid>
    {
        public string Url { get; set; }

        public string DescriptionRr { get; set; }

        public byte[] PictureData { get; set; }

        public Guid TripId { get; set; }
    }
}
