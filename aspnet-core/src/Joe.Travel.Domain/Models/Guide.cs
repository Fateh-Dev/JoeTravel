using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Joe.Travel.Models
{
    public class Guide : FullAuditedAggregateRoot<Guid>
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public ICollection<Trip> Trips { get; set; }

        

        public Guide()
        {
        }

        public Guide(Guid id, string firstname, string lastname) :
            base(id)
        {
            SetName (firstname);
            Lastname = lastname;
        }

        private void SetName(string firstname)
        {
            Firstname =
                Check.NotNullOrWhiteSpace(firstname, nameof(firstname), 200);
        }
    }
}
