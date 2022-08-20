using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Joe.Travel.Models;
using Volo.Abp.Domain.Repositories;

namespace Joe.Travel
{
    public interface ITripRepository : IRepository<Trip, Guid>
    {
        Task<List<TripWithDetails>> GetListAsync(
            string sorting,
            int skipCount,
            int maxResultCount,
            CancellationToken cancellationToken = default
        );

        Task<TripWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default);
        
    }
}