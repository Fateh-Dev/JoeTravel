using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Joe.Travel;
using Joe.Travel.EntityFrameworkCore;
using Joe.Travel.Models;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TripStore.Trips
{
    public class
    EfCoreTripRepository
    : EfCoreRepository<TravelDbContext, Trip, Guid>, ITripRepository
    {
        public EfCoreTripRepository(
            IDbContextProvider<TravelDbContext> dbContextProvider
        ) :
            base(dbContextProvider)
        {
        }

        public async Task<List<TripWithDetails>>
        GetListAsync(
            string sorting,
            int skipCount,
            int maxResultCount,
            CancellationToken cancellationToken = default
        )
        {
            var query = await ApplyFilterAsync();

            return await query
                .OrderBy(!string.IsNullOrWhiteSpace(sorting)
                    ? sorting
                    : nameof(Trip.Title))
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<TripWithDetails>
        GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = await ApplyFilterAsync();

            return await query
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        private async Task<IQueryable<TripWithDetails>> ApplyFilterAsync()
        {
            var dbContext = await GetDbContextAsync();

            return (
            await GetDbSetAsync()
            ) // .Include(x => x.Activities)
                .Join(dbContext.Set<Guide>(),
                trip => trip.GuideId,
                guide => guide.Id,
                (trip, guide) => new { trip, guide })
                .Select(x =>
                    new TripWithDetails {
                        Id = x.trip.Id,
                        Title = x.trip.Title,
                        Description = x.trip.Description,
                        Difficulty = x.trip.Difficulty.ToString(),
                        GuideName = x.guide.Firstname + " " + x.guide.Lastname,
                        Rating = x.trip.Rating,
                        Duration =
                            x.trip.Duration.ToString() +
                            " " +
                            x.trip.DurationUnit.ToString() +
                            ((x.trip.Duration != 1) ? "s" : ""),
                        TripSize = x.trip.TripSize.ToString(),
                        Thumbnail = x.trip.Thumbnail,
                        ActivityNames =
                            (
                            from TripActivity in x.trip.Activities
                            join Activity
                            in dbContext.Set<Activity>()
                            on TripActivity.ActivityId
                            equals Activity.Id
                            select Activity.DescriptionFr
                            ).ToArray(),
                        RiskNames =
                            (
                            from TripRisk in x.trip.Risks
                            join Risk
                            in dbContext.Set<Risk>()
                            on TripRisk.RiskId
                            equals Risk.Id
                            select Risk.DescriptionFr
                            ).ToArray(),
                        NotAllowedStuffNames =
                            (
                            from TripNotAllowedStuff in x.trip.NotAllowedStuffs
                            join NotAllowedStuff
                            in dbContext.Set<NotAllowedStuff>()
                            on TripNotAllowedStuff.NotAllowedStuffId
                            equals NotAllowedStuff.Id
                            select NotAllowedStuff.DescriptionFr
                            ).ToArray(),
                        NotSuitableForNames =
                            (
                            from TripNotSuitableFor in x.trip.NotSuitableFors
                            join NotSuitableFor
                            in dbContext.Set<NotSuitableFor>()
                            on TripNotSuitableFor.NotSuitableForId
                            equals NotSuitableFor.Id
                            select NotSuitableFor.DescriptionFr
                            ).ToArray(),
                        LogingNames =
                            (
                            from TripLoging in x.trip.Logings
                            join Loging
                            in dbContext.Set<Loging>()
                            on TripLoging.LogingId
                            equals Loging.Id
                            select Loging.DescriptionFr
                            ).ToArray(),
                        RequiredStuffNames =
                            (
                            from TripRequiredStuff in x.trip.RequiredStuffs
                            join RequiredStuff
                            in dbContext.Set<RequiredStuff>()
                            on TripRequiredStuff.RequiredStuffId
                            equals RequiredStuff.Id
                            select RequiredStuff.DescriptionFr
                            ).ToArray(),
                        IncludedStuffNames =
                            (
                            from TripIncludedStuff in x.trip.IncludedStuffs
                            join IncludedStuff
                            in dbContext.Set<IncludedStuff>()
                            on TripIncludedStuff.IncludedStuffId
                            equals IncludedStuff.Id
                            select IncludedStuff.DescriptionFr
                            ).ToArray()
                    });
        }

        public override Task<IQueryable<Trip>> WithDetailsAsync()
        {
            return base.WithDetailsAsync(x => x.Activities,
            y => y.Risks,
            z => z.NotAllowedStuffs,
            v => v.NotSuitableFors,
            b => b.IncludedStuffs,
            f => f.Logings,
            g => g.RequiredStuffs);
        }
    }
}
