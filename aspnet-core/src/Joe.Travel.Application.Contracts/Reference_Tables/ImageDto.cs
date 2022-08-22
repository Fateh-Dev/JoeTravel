using System;
using Volo.Abp.Application.Dtos;

namespace Joe.Travel
{
    public class ImageDto : EntityDto<Guid>
    {
        public byte[] PictureData { get; set; }
    }
}
