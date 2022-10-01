using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Joe.Travel.Models;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Joe.Travel
{
    [ApiExplorerSettings(GroupName = "Xplorer_Api", IgnoreApi = false)]
    public class TripAppService : TravelAppService, ITripAppService
    {
        private readonly ITripRepository _tripRepository;

        private readonly TripManager _tripManager;

        private readonly IRepository<Activity, Guid> _activityRepository;

        private readonly IRepository<Risk, Guid> _riskRepository;

        private readonly IRepository<Guide, Guid> _guideRepository;

        // private readonly IRepository<Image, Guid> _imageRepository;

        private readonly IRepository<NotAllowedStuff, Guid>
            _notAllowedStuffRepository;

        private readonly IRepository<NotSuitableFor, Guid>
            _notSuitableForRepository;

        private readonly IRepository<Loging, Guid> _logingRepository;

        private readonly IRepository<IncludedStuff, Guid>
            _includedStuffRepository;

        private readonly IRepository<RequiredStuff, Guid>
            _requiredStuffRepository;

        public TripAppService(
            ITripRepository tripRepository,
            TripManager tripManager,
            IRepository<Activity, Guid> activityRepository,
            IRepository<Risk, Guid> riskRepository,
            IRepository<Guide, Guid> guideRepository,
            IRepository<NotAllowedStuff, Guid> notAllowedStuffRepository,
            IRepository<NotSuitableFor, Guid> notSuitableForkRepository,
            IRepository<Loging, Guid> logingepository,
            IRepository<IncludedStuff, Guid> includedStuffRepository,
            IRepository<RequiredStuff, Guid> requiredStuffRepository
        // IRepository<Image, Guid> imageRepository
        )
        {
            _tripManager = tripManager;
            _tripRepository = tripRepository;
            _activityRepository = activityRepository;
            _guideRepository = guideRepository;
            _riskRepository = riskRepository;
            _notAllowedStuffRepository = notAllowedStuffRepository;
            _notSuitableForRepository = notSuitableForkRepository;
            _logingRepository = logingepository;
            _requiredStuffRepository = requiredStuffRepository;
            _includedStuffRepository = includedStuffRepository;
            // _imageRepository = imageRepository;
        }

        public async Task<PagedResultDto<TripDto>>
        GetListAsync(TripGetListInput input)
        {
            var trips =
                await _tripRepository
                    .GetListAsync(input.Sorting,
                    input.SkipCount,
                    input.MaxResultCount);
            var totalCount = await _tripRepository.CountAsync();
            return new PagedResultDto<TripDto>(totalCount,
                ObjectMapper.Map<List<TripWithDetails>, List<TripDto>>(trips));
        }

        public async Task<PagedResultDto<TripDto>>
        GetHomeListAsync(TripGetListInput input)
        {
            var trips =
                await _tripRepository
                    .GetHomeListAsync(input.Sorting,
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Title);
            var totalCount = await _tripRepository.CountAsync();
            return new PagedResultDto<TripDto>(totalCount,
                ObjectMapper.Map<List<TripWithOutDetails>, List<TripDto>>(trips));
        }

        public async Task<PagedResultDto<TripDto>>
        GetWishlistAsync(TripGetListInput input)
        {
            var trips =
                await _tripRepository
                    .GetHomeListAsync(input.Sorting,
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Title);
            var totalCount = await _tripRepository.CountAsync();
            return new PagedResultDto<TripDto>(totalCount,
                ObjectMapper.Map<List<TripWithOutDetails>, List<TripDto>>(trips));
        }




        public async Task CreateAsync(CreateUpdateTripDto input)
        {
            await _tripManager
                .CreateAsync(input.Title,
                input.GuideId,
                input.Description,
                input.Difficulty,
                // input.Duration,
                // input.TripSize,
                // input.DurationUnit,
                input.ActivityNames,
                input.RiskNames,
                input.NotAllowedStuffNames,
                input.NotSuitableForNames,
                input.LogingNames,
                input.IncludedStuffNames,
                input.RequiredStuffNames);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _tripRepository.DeleteAsync(id);
        }

        public async Task<TripDto> GetAsync(Guid id)
        {
            var trip = await _tripRepository.GetAsync(id);
            return ObjectMapper.Map<TripWithDetails, TripDto>(trip);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateTripDto input)
        {
            var trip = await _tripRepository.GetAsync(id, includeDetails: true);
            await _tripManager
                .UpdateAsync(trip,
                input.GuideId,
                input.Title,
                input.Description,
                input.Difficulty,
                input.ActivityNames,
                input.RiskNames,
                input.NotAllowedStuffNames,
                input.NotSuitableForNames,
                input.LogingNames,
                input.IncludedStuffNames,
                input.RequiredStuffNames);
        }

        public async Task<ListResultDto<ActivityLookupDto>>
        GetActivityLookupAsync()
        {
            var activities = await _activityRepository.GetListAsync();
            return new ListResultDto<ActivityLookupDto>(ObjectMapper
                    .Map<List<Activity>, List<ActivityLookupDto>>(activities));
        }

        public async Task<ListResultDto<RiskLookupDto>> GetRiskLookupAsync()
        {
            var risks = await _riskRepository.GetListAsync();
            return new ListResultDto<RiskLookupDto>(ObjectMapper
                    .Map<List<Risk>, List<RiskLookupDto>>(risks));
        }

        public async Task<ListResultDto<GuideLookupDto>> GetGuideLookupAsync()
        {
            var guides = await _guideRepository.GetListAsync();
            return new ListResultDto<GuideLookupDto>(ObjectMapper
                    .Map<List<Guide>, List<GuideLookupDto>>(guides));
        }

        public async Task<ListResultDto<NotAllowedStuffLookupDto>>
        GetNotAllowedStuffLookupAsync()
        {
            var el = await _notAllowedStuffRepository.GetListAsync();
            return new ListResultDto<NotAllowedStuffLookupDto>(ObjectMapper
                    .Map
                    <List<NotAllowedStuff>, List<NotAllowedStuffLookupDto>
                    >(el));
        }

        public async Task<ListResultDto<NotSuitableForLookupDto>>
        GetNotSuitableForLookupAsync()
        {
            var el = await _notSuitableForRepository.GetListAsync();
            return new ListResultDto<NotSuitableForLookupDto>(ObjectMapper
                    .Map
                    <List<NotSuitableFor>, List<NotSuitableForLookupDto>>(el));
        }

        public async Task<ListResultDto<LogingLookupDto>> GetLogingLookupAsync()
        {
            var el = await _logingRepository.GetListAsync();
            return new ListResultDto<LogingLookupDto>(ObjectMapper
                    .Map<List<Loging>, List<LogingLookupDto>>(el));
        }

        public async Task<ListResultDto<IncludedStuffLookupDto>>
        GetIncludedStuffLookupAsync()
        {
            var el = await _includedStuffRepository.GetListAsync();
            return new ListResultDto<IncludedStuffLookupDto>(ObjectMapper
                    .Map
                    <List<IncludedStuff>, List<IncludedStuffLookupDto>>(el));
        }

        public async Task<ListResultDto<RequiredStuffLookupDto>>
        GetRequierdStuffLookupAsync()
        {
            var el = await _requiredStuffRepository.GetListAsync();
            return new ListResultDto<RequiredStuffLookupDto>(ObjectMapper
                    .Map
                    <List<RequiredStuff>, List<RequiredStuffLookupDto>>(el));
        }

        public async Task<Lookups> GetLookupsAtOnceAsync()
        {
            var risks = await _riskRepository.GetListAsync();
            var activities = await _activityRepository.GetListAsync();
            var notAllowed = await _notAllowedStuffRepository.GetListAsync();
            var notSuitable = await _notSuitableForRepository.GetListAsync();
            var required = await _requiredStuffRepository.GetListAsync();
            var loging = await _logingRepository.GetListAsync();
            var included = await _includedStuffRepository.GetListAsync();
            var guides = await _guideRepository.GetListAsync();
            Lookups L =
                new Lookups()
                {
                    Risks =
                        ObjectMapper
                            .Map<List<Risk>, List<RiskLookupDto>>(risks),
                    Activities =
                        ObjectMapper
                            .Map
                            <List<Activity>, List<ActivityLookupDto>
                            >(activities),
                    NotAllowedStuffs =
                        ObjectMapper
                            .Map
                            <List<NotAllowedStuff>,
                                List<NotAllowedStuffLookupDto>
                            >(notAllowed),
                    NotSuitableFors =
                        ObjectMapper
                            .Map
                            <List<NotSuitableFor>, List<NotSuitableForLookupDto>
                            >(notSuitable),
                    RequiredStuffs =
                        ObjectMapper
                            .Map
                            <List<RequiredStuff>, List<RequiredStuffLookupDto>
                            >(required),
                    Logings =
                        ObjectMapper
                            .Map<List<Loging>, List<LogingLookupDto>>(loging),
                    IncludedStuffs =
                        ObjectMapper
                            .Map
                            <List<IncludedStuff>, List<IncludedStuffLookupDto>
                            >(included),
                    Guides =
                        ObjectMapper
                            .Map
                            <List<Guide>, List<GuideLookupDto>
                            >(guides)
                };
            return L;
        }


        // public async Task<ListResultDto<ImageDto>> GetTripPictures()
        // {
        //     var el = await _imageRepository.GetListAsync();
        //     return new ListResultDto<ImageDto>(ObjectMapper
        //             .Map<List<Image>, List<ImageDto>>(el));
        // }
    }
}
