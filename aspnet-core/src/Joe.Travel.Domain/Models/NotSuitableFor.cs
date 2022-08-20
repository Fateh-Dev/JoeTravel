using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Joe.Travel.Models
{
    public class NotSuitableFor : AuditedAggregateRoot<Guid>
    {
        public string DescriptionFr { get; set; }

        public string DescriptionAr { get; set; }

        public NotSuitableFor()
        {
        }

        public NotSuitableFor(
            Guid id,
            string descriptionFr,
            string descriptionAr
        ) :
            base(id)
        {
            SetDescriptionFr (descriptionFr);
            SetDescriptionAr (descriptionAr);
        }

        private void SetDescriptionAr(string descriptionAr)
        {
            DescriptionAr =
                Check
                    .NotNullOrWhiteSpace(descriptionAr,
                    nameof(descriptionAr),
                    DescriptionConst.MaxLength);
        }

        private void SetDescriptionFr(string descriptionFr)
        {
            DescriptionFr =
                Check
                    .NotNullOrWhiteSpace(descriptionFr,
                    nameof(descriptionFr),
                    DescriptionConst.MaxLength);
        }
    }
}
