using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Joe.Travel
{
    public interface ITripAppService : IApplicationService
    {
        Task<PagedResultDto<TripDto>> GetListAsync(TripGetListInput input);

        Task<TripDto> GetAsync(Guid id);

        Task CreateAsync(CreateUpdateTripDto input);

        Task UpdateAsync(Guid id, CreateUpdateTripDto input);

        Task DeleteAsync(Guid id);

        Task<ListResultDto<RiskLookupDto>> GetRiskLookupAsync();

        Task<ListResultDto<ActivityLookupDto>> GetActivityLookupAsync();

        Task<ListResultDto<GuideLookupDto>> GetGuideLookupAsync();

        Task<ListResultDto<NotAllowedStuffLookupDto>>
        GetNotAllowedStuffLookupAsync();

        Task<ListResultDto<NotSuitableForLookupDto>>
        GetNotSuitableForLookupAsync();

        Task<ListResultDto<LogingLookupDto>> GetLogingLookupAsync();

        Task<ListResultDto<IncludedStuffLookupDto>>
        GetIncludedStuffLookupAsync();

        Task<ListResultDto<RequiredStuffLookupDto>>
        GetRequierdStuffLookupAsync();

        Task<Lookups> GetLookupsAtOnceAsync();
    }
}
