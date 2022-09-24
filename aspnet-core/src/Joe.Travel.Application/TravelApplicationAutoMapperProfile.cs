using AutoMapper;
using Joe.Travel.Models;

namespace Joe.Travel;

public class TravelApplicationAutoMapperProfile : Profile
{
    public TravelApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
         CreateMap<Trip ,TripDto>();
         CreateMap<CreateUpdateTripDto ,Trip>();
         CreateMap<TripWithDetails ,Trip>();
         CreateMap<TripWithDetails ,TripDto>();
         CreateMap<TripWithOutDetails ,TripDto>();

         CreateMap<Activity ,ActivityDto>();
         CreateMap<Activity ,ActivityLookupDto>();
         CreateMap<CreateUpdateActivityDto ,Activity>();

         CreateMap<Risk ,RiskDto>();
         CreateMap<Risk ,RiskLookupDto>(); 
         CreateMap<CreateUpdateRiskDto ,Risk>();

         CreateMap<NotAllowedStuff ,NotAllowedStuffDto>();
         CreateMap<NotAllowedStuff ,NotAllowedStuffLookupDto>();
         CreateMap<CreateUpdateNotAllowedStuffDto ,NotAllowedStuff>();

         CreateMap<NotSuitableFor ,NotSuitableForDto>();
         CreateMap<NotSuitableFor ,NotSuitableForLookupDto>();
         CreateMap<CreateUpdateNotSuitableForDto ,NotSuitableFor>();

         CreateMap<Loging ,LogingDto>();
         CreateMap<Loging ,LogingLookupDto>();
         CreateMap<CreateUpdateLogingDto ,Loging>();

         CreateMap<RequiredStuff ,RequiredStuffDto>();
         CreateMap<RequiredStuff ,RequiredStuffLookupDto>();
         CreateMap<CreateUpdateRequiredStuffDto ,RequiredStuff>();

         CreateMap<IncludedStuff ,IncludedStuffDto>();
         CreateMap<IncludedStuff ,IncludedStuffLookupDto>();
         CreateMap<CreateUpdateIncludedStuffDto ,IncludedStuff>();

         CreateMap<Guide ,GuideDto>();
         //TODO Map Two Fields To One Field
         CreateMap<Guide ,GuideLookupDto>().ForMember(s=>s.Name, d =>
             d.MapFrom(fa=>
                 (fa.Firstname+" "+fa.Lastname)
             )
         );
         CreateMap<CreateUpdateGuideDto ,Guide>();

         CreateMap<Image ,ImageDto>();
    }
}
