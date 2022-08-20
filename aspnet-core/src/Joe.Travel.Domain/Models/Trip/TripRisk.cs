using System;
using Volo.Abp.Domain.Entities;

namespace Joe.Travel.Models
{
    public class TripRisk : Entity
    {
        public Guid TripId { get; set; }

        public Guid RiskId { get; set; }

        public TripRisk()
        {
        }

        public TripRisk(Guid tripId, Guid riskId)
        {
            TripId = tripId;
            RiskId = riskId;
        }

        // public Difficulty Difficulty { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { TripId, RiskId };
        }
    }
}
