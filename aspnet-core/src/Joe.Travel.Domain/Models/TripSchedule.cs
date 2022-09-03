using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Joe.Travel.Models
{
    class TripSchedule : FullAuditedAggregateRoot<Guid>
    {
        public Guid TripId { get; set; }

        public Trip Trip { get; set; }

        public Guid GuideId { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Price> Prices { get; set; }

        // public ICollection<Review> Reviews { get; set; }
        public ICollection<SubscribedAt> subscribedTourists { get; set; }

        public TripSchedule()
        {
        }

        public TripSchedule(Guid id, Guid tripId, Guid guideId, DateTime date) :
            base(id)
        {
            TripId = tripId;
            GuideId = guideId;
            Date = date;
        }
    }
}
