import type { CreateUpdateRiskDto, RiskDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class RiskService {
  apiName = 'Default';

  create = (input: CreateUpdateRiskDto) =>
    this.restService.request<any, RiskDto>({
      method: 'POST',
      url: '/api/app/risk',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/risk/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, RiskDto>({
      method: 'GET',
      url: `/api/app/risk/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<RiskDto>>({
      method: 'GET',
      url: '/api/app/risk',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateRiskDto) =>
    this.restService.request<any, RiskDto>({
      method: 'PUT',
      url: `/api/app/risk/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
