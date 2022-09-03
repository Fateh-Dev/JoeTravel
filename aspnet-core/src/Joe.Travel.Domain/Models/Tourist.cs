using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Joe.Travel.Models
{
    class Tourist : FullAuditedAggregateRoot<Guid>
    {
        public Tourist(Guid id) :
            base(id)
        {
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Username { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string Languages { get; set; }

        public string Picture { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public Wilaya Wilaya { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        // public ICollection<Review> Reviews { get; set; }

        // public ICollection<WishList> WishLists { get; set; }

        public ICollection<SubscribedAt> SubscribedTrips { get; set; }
    }
}
