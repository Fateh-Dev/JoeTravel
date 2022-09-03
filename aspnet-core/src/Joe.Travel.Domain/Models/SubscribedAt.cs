using System;
using Volo.Abp.Domain.Entities;

namespace Joe.Travel.Models
{
    class SubscribedAt : Entity
    {
        public Guid TripScheduleId { get; set; }

        public Guid TouristId { get; set; }

        public SubscribedAt()
        {
        }

        public SubscribedAt(Guid tripId, Guid touristId)
        {
            TripScheduleId = tripId;
            TouristId = touristId;
        }

        public override object[] GetKeys()
        {
            return new object[] { TripScheduleId, TouristId };
        }
    }
}
