import type { ActivityDto, CreateUpdateActivityDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ActivityService {
  apiName = 'Default';

  create = (input: CreateUpdateActivityDto) =>
    this.restService.request<any, ActivityDto>({
      method: 'POST',
      url: '/api/app/activity',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/activity/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ActivityDto>({
      method: 'GET',
      url: `/api/app/activity/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ActivityDto>>({
      method: 'GET',
      url: '/api/app/activity',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateActivityDto) =>
    this.restService.request<any, ActivityDto>({
      method: 'PUT',
      url: `/api/app/activity/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
