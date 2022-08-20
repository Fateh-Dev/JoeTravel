using System;
using Volo.Abp.Domain.Entities;

namespace Joe.Travel.Models
{
    public class TripNotSuitableFor : Entity
    {
        public Guid TripId { get; set; }

        public Guid NotSuitableForId { get; set; }

        public TripNotSuitableFor()
        {
        }

        public TripNotSuitableFor(Guid tripId, Guid notSuitableFor)
        {
            TripId = tripId;
            NotSuitableForId = notSuitableFor;
        }

        // public Difficulty Difficulty { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { TripId, NotSuitableForId };
        }
    }
}
