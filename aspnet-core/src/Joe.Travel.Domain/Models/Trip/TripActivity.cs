using System;
using Volo.Abp.Domain.Entities;

namespace Joe.Travel.Models
{
    public class TripActivity : Entity
    {
        public Guid TripId { get; set; }

        public Guid ActivityId { get; set; }

        public TripActivity()
        {
        }

        public TripActivity(Guid tripId, Guid activityId)
        {
            TripId = tripId;
            ActivityId = activityId;
        }

        // public Difficulty Difficulty { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { TripId, ActivityId };
        }
    }
}
