using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Joe.Travel.Models
{
    class Price : AuditedAggregateRoot<Guid>
    {
        public double value { get; set; }

        public string Category { get; set; }

        public Guid TripScheduleId { get; set; }

        public Price(Guid id) :
            base(id)
        {
        }
    }
}
