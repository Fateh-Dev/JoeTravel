using System;
using Volo.Abp.Domain.Entities;

namespace Joe.Travel.Models
{
    public class TripLoging : Entity
    {
        public Guid TripId { get; set; }

        public Guid LogingId { get; set; }

        public TripLoging()
        {
        }

        public TripLoging(Guid tripId, Guid logingId)
        {
            TripId = tripId;
            LogingId = logingId;
        }

        // public Difficulty Difficulty { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { TripId, LogingId };
        }
    }
}
