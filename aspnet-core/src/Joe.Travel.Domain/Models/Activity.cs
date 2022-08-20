using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Joe.Travel.Models
{
    public class Activity : AuditedAggregateRoot<Guid>
    {
        public string DescriptionFr { get; set; }

        public string DescriptionAr { get; set; }

        public Activity()
        {
        }

        public Activity(Guid id, string descriptionFr, string descriptionAr) :
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
                    ActivityConst.MaxDescriptionLength);
        }

        private void SetDescriptionFr(string descriptionFr)
        {
            DescriptionFr =
                Check
                    .NotNullOrWhiteSpace(descriptionFr,
                    nameof(descriptionFr),
                    ActivityConst.MaxDescriptionLength);
        }
    }
}
