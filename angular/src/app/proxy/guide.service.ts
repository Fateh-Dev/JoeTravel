import type { CreateUpdateGuideDto, GuideDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GuideService {
  apiName = 'Default';

  create = (input: CreateUpdateGuideDto) =>
    this.restService.request<any, GuideDto>({
      method: 'POST',
      url: '/api/app/guide',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/guide/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, GuideDto>({
      method: 'GET',
      url: `/api/app/guide/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<GuideDto>>({
      method: 'GET',
      url: '/api/app/guide',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateGuideDto) =>
    this.restService.request<any, GuideDto>({
      method: 'PUT',
      url: `/api/app/guide/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
