using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Joe.Travel.Models
{
    public class Risk : AuditedAggregateRoot<Guid>
    {
        public string DescriptionFr { get; set; }

        public string DescriptionAr { get; set; }

        public Risk()
        {
        }

        public Risk(Guid id, string descriptionFr, string descriptionAr) :
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
                    128);
        }

        private void SetDescriptionFr(string descriptionFr)
        {
            DescriptionFr =
                Check
                    .NotNullOrWhiteSpace(descriptionFr,
                    nameof(descriptionFr),
                    128);
        }
    }
}
