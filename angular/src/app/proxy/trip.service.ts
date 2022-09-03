import type { ActivityLookupDto, CreateUpdateTripDto, GuideLookupDto, IncludedStuffLookupDto, LogingLookupDto, Lookups, NotAllowedStuffLookupDto, NotSuitableForLookupDto, RequiredStuffLookupDto, RiskLookupDto, TripDto, TripGetListInput } from './models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TripService {
  apiName = 'Default';

  create = (input: CreateUpdateTripDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/trip',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/trip/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, TripDto>({
      method: 'GET',
      url: `/api/app/trip/${id}`,
    },
    { apiName: this.apiName });

  getActivityLookup = () =>
    this.restService.request<any, ListResultDto<ActivityLookupDto>>({
      method: 'GET',
      url: '/api/app/trip/activity-lookup',
    },
    { apiName: this.apiName });

  getGuideLookup = () =>
    this.restService.request<any, ListResultDto<GuideLookupDto>>({
      method: 'GET',
      url: '/api/app/trip/guide-lookup',
    },
    { apiName: this.apiName });

  getIncludedStuffLookup = () =>
    this.restService.request<any, ListResultDto<IncludedStuffLookupDto>>({
      method: 'GET',
      url: '/api/app/trip/included-stuff-lookup',
    },
    { apiName: this.apiName });

  getList = (input: TripGetListInput) =>
    this.restService.request<any, PagedResultDto<TripDto>>({
      method: 'GET',
      url: '/api/app/trip',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getLogingLookup = () =>
    this.restService.request<any, ListResultDto<LogingLookupDto>>({
      method: 'GET',
      url: '/api/app/trip/loging-lookup',
    },
    { apiName: this.apiName });

  getLookupsAtOnce = () =>
    this.restService.request<any, Lookups>({
      method: 'GET',
      url: '/api/app/trip/lookups-at-once',
    },
    { apiName: this.apiName });

  getNotAllowedStuffLookup = () =>
    this.restService.request<any, ListResultDto<NotAllowedStuffLookupDto>>({
      method: 'GET',
      url: '/api/app/trip/not-allowed-stuff-lookup',
    },
    { apiName: this.apiName });

  getNotSuitableForLookup = () =>
    this.restService.request<any, ListResultDto<NotSuitableForLookupDto>>({
      method: 'GET',
      url: '/api/app/trip/not-suitable-for-lookup',
    },
    { apiName: this.apiName });

  getRequierdStuffLookup = () =>
    this.restService.request<any, ListResultDto<RequiredStuffLookupDto>>({
      method: 'GET',
      url: '/api/app/trip/requierd-stuff-lookup',
    },
    { apiName: this.apiName });

  getRiskLookup = () =>
    this.restService.request<any, ListResultDto<RiskLookupDto>>({
      method: 'GET',
      url: '/api/app/trip/risk-lookup',
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateTripDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/trip/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
