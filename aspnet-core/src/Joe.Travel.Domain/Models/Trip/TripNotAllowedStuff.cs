using System;
using Volo.Abp.Domain.Entities;

namespace Joe.Travel.Models
{
    public class TripNotAllowedStuff : Entity
    {
        public Guid TripId { get; set; }

        public Guid NotAllowedStuffId { get; set; }

        public TripNotAllowedStuff()
        {
        }

        public TripNotAllowedStuff(Guid tripId, Guid notAllowedStuffId)
        {
            TripId = tripId;
            NotAllowedStuffId = notAllowedStuffId;
        }

        // public Difficulty Difficulty { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { TripId, NotAllowedStuffId };
        }
    }
}
