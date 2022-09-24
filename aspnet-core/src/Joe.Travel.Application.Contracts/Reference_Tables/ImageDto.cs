using System;
using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class ImageDto : EntityDto<Guid>
    {
        // public Guid TripId { get; set; }

        // public string DescriptionRr { get; set; }

        public byte[] PictureData { get; set; }=null;
    }
}
