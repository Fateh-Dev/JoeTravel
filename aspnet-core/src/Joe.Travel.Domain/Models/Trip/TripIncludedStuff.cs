using System;
using Volo.Abp.Domain.Entities;

namespace Joe.Travel.Models
{
    public class TripIncludedStuff : Entity
    {
        public Guid TripId { get; set; }

        public Guid IncludedStuffId { get; set; }

        public TripIncludedStuff()
        {
        }

        public TripIncludedStuff(Guid tripId, Guid includedStuffId)
        {
            TripId = tripId;
            IncludedStuffId = includedStuffId;
        }

        // public Difficulty Difficulty { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { TripId, IncludedStuffId };
        }
    }
}
