using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Joe.Travel.Models;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Joe.Travel
{
    public class TripManager : DomainService
    {
        private readonly ITripRepository _tripRepository;

        private readonly IRepository<Activity, Guid> _activityRepository;

        private readonly IRepository<Risk, Guid> _riskRepository;

        private readonly IRepository<NotAllowedStuff, Guid>
            _notAllowedStuffRepository;

        private readonly IRepository<NotSuitableFor, Guid>
            _notSuitableForRepository;

        private readonly IRepository<Loging, Guid> _logingRepository;

        private readonly IRepository<IncludedStuff, Guid>
            _includedStuffRepository;

        private readonly IRepository<RequiredStuff, Guid>
            _requiredStuffRepository;

        public TripManager(
            ITripRepository tripRepository,
            IRepository<Activity, Guid> activityRepository,
            IRepository<Risk, Guid> riskRepository,
            IRepository<NotAllowedStuff, Guid> notAllowedStuffRepository,
            IRepository<NotSuitableFor, Guid> notSuitableForkRepository,
            IRepository<Loging, Guid> logingepository,
            IRepository<IncludedStuff, Guid> includedStuffRepository,
            IRepository<RequiredStuff, Guid> requiredStuffRepository
        )
        {
            _tripRepository = tripRepository;
            _activityRepository = activityRepository;
            _riskRepository = riskRepository;
            _notAllowedStuffRepository = notAllowedStuffRepository;
            _notSuitableForRepository = notSuitableForkRepository;
            _logingRepository = logingepository;
            _requiredStuffRepository = requiredStuffRepository;
            _includedStuffRepository = includedStuffRepository;
        }

        public async Task
        CreateAsync(
            string title,
            Guid guideId,
            string description,
            Difficulty difficulty,
            [CanBeNull] string[] activityNames,
            [CanBeNull] string[] riskNames,
            [CanBeNull] string[] notAllowedStuffNames,
            [CanBeNull] string[] notSuitableForNames,
            [CanBeNull] string[] logingNames,
            [CanBeNull] string[] IncludedStuffNames,
            [CanBeNull] string[] RequiredStuffNames
        )
        {
            var trip =
                new Trip(GuidGenerator.Create(),
                    guideId,
                    title,
                    description,
                    difficulty);

            await SetActivitiesAsync(trip, activityNames);
            await SetRisksAsync(trip, riskNames);
            await SetNotAllowedAsync(trip, notAllowedStuffNames);
            await SetNotSuitableAsync(trip, notSuitableForNames);
            await SetLogingAsync(trip, logingNames);
            await SetIncludedAsync(trip, IncludedStuffNames);
            await SetRequiredAsync(trip, RequiredStuffNames);


            string someUrl = "MyStaticFiles/";
            Random r = new Random();
            int rInt = r.Next(1, 20);
            using (var webClient = new WebClient())
            {
                trip.Thumbnail =
                    webClient.DownloadData(someUrl + "images/" +rInt+ ".jpg");
            }

            await _tripRepository.InsertAsync(trip);
        }

        public async Task
        UpdateAsync(
            Trip trip,
            Guid GuideId,
            string title,
            string description,
            Difficulty difficulty,
            [CanBeNull] string[] activityNames,
            [CanBeNull] string[] riskNames,
            [CanBeNull] string[] notAllowedStuffNames,
            [CanBeNull] string[] notSuitableForNames,
            [CanBeNull] string[] logingNames,
            [CanBeNull] string[] IncludedStuffNames,
            [CanBeNull] string[] RequiredStuffNames
        )
        {
            trip.SetTitle(title);
            trip.GuideId = GuideId;

            await SetActivitiesAsync(trip, activityNames);
            await SetRisksAsync(trip, riskNames);

            await SetNotAllowedAsync(trip, notAllowedStuffNames);
            await SetNotSuitableAsync(trip, notSuitableForNames);
            await SetLogingAsync(trip, logingNames);
            await SetIncludedAsync(trip, IncludedStuffNames);
            await SetRequiredAsync(trip, RequiredStuffNames);

            await _tripRepository.UpdateAsync(trip);
        }

        private async Task
        SetActivitiesAsync(Trip trip, [CanBeNull] string[] activityNames)
        {
            if (activityNames == null || !activityNames.Any())
            {
                trip.RemoveAllActivities();
                return;
            }

            var query =
                (await _activityRepository.GetQueryableAsync())
                    .Where(x => activityNames.Contains(x.DescriptionFr))
                    .Select(x => x.Id)
                    .Distinct();

            var activityIds = await AsyncExecuter.ToListAsync(query);
            if (!activityIds.Any())
            {
                return;
            }

            trip.RemoveAllActivitiesExceptGivenIds(activityIds);

            foreach (var activityId in activityIds)
            {
                trip.AddActivity(activityId);
            }
        }

        private async Task
        SetRisksAsync(Trip trip, [CanBeNull] string[] riskNames)
        {
            if (riskNames == null || !riskNames.Any())
            {
                trip.RemoveAllRisks();
                return;
            }

            var query =
                (await _riskRepository.GetQueryableAsync())
                    .Where(x => riskNames.Contains(x.DescriptionFr))
                    .Select(x => x.Id)
                    .Distinct();

            var riskIds = await AsyncExecuter.ToListAsync(query);
            if (!riskIds.Any())
            {
                return;
            }

            trip.RemoveAllRisksExceptGivenIds(riskIds);

            foreach (var riskId in riskIds)
            {
                trip.AddRisks(riskId);
            }
        }

        private async Task
        SetNotAllowedAsync(Trip trip, [CanBeNull] string[] Names)
        {
            if (Names == null || !Names.Any())
            {
                trip.RemoveAllNotAllowedStuffs();
                return;
            }

            var query =
                (await _notAllowedStuffRepository.GetQueryableAsync())
                    .Where(x => Names.Contains(x.DescriptionFr))
                    .Select(x => x.Id)
                    .Distinct();

            var Ids = await AsyncExecuter.ToListAsync(query);
            if (!Ids.Any())
            {
                return;
            }

            trip.RemoveAllNotAllowedStuffsExceptGivenIds(Ids);

            foreach (var id in Ids)
            {
                trip.AddNotAllowedStuffs(id);
            }
        }

        private async Task
        SetNotSuitableAsync(Trip trip, [CanBeNull] string[] Names)
        {
            if (Names == null || !Names.Any())
            {
                trip.RemoveAllNotSuitableFors();
                return;
            }

            var query =
                (await _notSuitableForRepository.GetQueryableAsync())
                    .Where(x => Names.Contains(x.DescriptionFr))
                    .Select(x => x.Id)
                    .Distinct();

            var Ids = await AsyncExecuter.ToListAsync(query);
            if (!Ids.Any())
            {
                return;
            }

            trip.RemoveAllNotSuitableForsExceptGivenIds(Ids);

            foreach (var id in Ids)
            {
                trip.AddNotSuitableFors(id);
            }
        }

        private async Task SetLogingAsync(Trip trip, [CanBeNull] string[] Names)
        {
            if (Names == null || !Names.Any())
            {
                trip.RemoveAllLogings();
                return;
            }

            var query =
                (await _logingRepository.GetQueryableAsync())
                    .Where(x => Names.Contains(x.DescriptionFr))
                    .Select(x => x.Id)
                    .Distinct();

            var Ids = await AsyncExecuter.ToListAsync(query);
            if (!Ids.Any())
            {
                return;
            }

            trip.RemoveAllLogingsExceptGivenIds(Ids);

            foreach (var id in Ids)
            {
                trip.AddLogings(id);
            }
        }

        private async Task
        SetIncludedAsync(Trip trip, [CanBeNull] string[] Names)
        {
            if (Names == null || !Names.Any())
            {
                trip.RemoveAllIncludedStuffs();
                return;
            }

            var query =
                (await _includedStuffRepository.GetQueryableAsync())
                    .Where(x => Names.Contains(x.DescriptionFr))
                    .Select(x => x.Id)
                    .Distinct();

            var Ids = await AsyncExecuter.ToListAsync(query);
            if (!Ids.Any())
            {
                return;
            }

            trip.RemoveAllIncludedStuffsExceptGivenIds(Ids);

            foreach (var id in Ids)
            {
                trip.AddIncludedStuffs(id);
            }
        }

        private async Task
        SetRequiredAsync(Trip trip, [CanBeNull] string[] Names)
        {
            if (Names == null || !Names.Any())
            {
                trip.RemoveAllRequiredStuffs();
                return;
            }

            var query =
                (await _requiredStuffRepository.GetQueryableAsync())
                    .Where(x => Names.Contains(x.DescriptionFr))
                    .Select(x => x.Id)
                    .Distinct();

            var Ids = await AsyncExecuter.ToListAsync(query);
            if (!Ids.Any())
            {
                return;
            }

            trip.RemoveAllRequiredStuffsExceptGivenIds(Ids);

            foreach (var id in Ids)
            {
                trip.AddRequiredStuffs(id);
            }
        }
    }
}
