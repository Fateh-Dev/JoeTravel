using System;
using Volo.Abp.Domain.Entities;

namespace Joe.Travel.Models
{
    public class TripRequiredStuff : Entity
    {
        public Guid TripId { get; set; }

        public Guid RequiredStuffId { get; set; }

        public TripRequiredStuff()
        {
        }

        public TripRequiredStuff(Guid tripId, Guid requiredStuff)
        {
            TripId = tripId;
            RequiredStuffId = requiredStuff;
        }

        // public Difficulty Difficulty { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { TripId, RequiredStuffId };
        }
    }
}
