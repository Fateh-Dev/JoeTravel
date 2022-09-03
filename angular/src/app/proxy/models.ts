import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { Difficulty } from './difficulty.enum';
import type { TripSize } from './trip-size.enum';
import type { DurationUnit } from './duration-unit.enum';

export interface ActivityDto extends EntityDto<string> {
  descriptionFr?: string;
  descriptionAr?: string;
}

export interface ActivityLookupDto extends EntityDto<string> {
  descriptionFr?: string;
}

export interface CreateUpdateActivityDto {
  descriptionFr: string;
  descriptionAr?: string;
}

export interface CreateUpdateGuideDto {
  firstname: string;
  lastname?: string;
}

export interface CreateUpdateRiskDto {
  descriptionFr: string;
  descriptionAr?: string;
}

export interface CreateUpdateTripDto {
  title: string;
  guideId?: string;
  description: string;
  difficulty: Difficulty;
  duration: number;
  tripSize: TripSize;
  durationUnit: DurationUnit;
  activityNames: string[];
  riskNames: string[];
  includedStuffNames: string[];
  logingNames: string[];
  notAllowedStuffNames: string[];
  notSuitableForNames: string[];
  requiredStuffNames: string[];
}

export interface GuideDto extends EntityDto<string> {
  firstname?: string;
  lastname?: string;
}

export interface GuideLookupDto extends EntityDto<string> {
  name?: string;
}

export interface IncludedStuffLookupDto extends EntityDto<string> {
  descriptionFr?: string;
}

export interface LogingLookupDto extends EntityDto<string> {
  descriptionFr?: string;
}

export interface Lookups extends EntityDto<string> {
  logings: LogingLookupDto[];
  notAllowedStuffs: NotAllowedStuffLookupDto[];
  activities: ActivityLookupDto[];
  risks: RiskLookupDto[];
  requiredStuffs: RequiredStuffLookupDto[];
  includedStuffs: IncludedStuffLookupDto[];
  notSuitableFors: NotSuitableForLookupDto[];
}

export interface NotAllowedStuffLookupDto extends EntityDto<string> {
  descriptionFr?: string;
}

export interface NotSuitableForLookupDto extends EntityDto<string> {
  descriptionFr?: string;
}

export interface RequiredStuffLookupDto extends EntityDto<string> {
  descriptionFr?: string;
}

export interface RiskDto extends EntityDto<string> {
  descriptionFr?: string;
  descriptionAr?: string;
}

export interface RiskLookupDto extends EntityDto<string> {
  descriptionFr?: string;
}

export interface TripDto extends EntityDto<string> {
  title?: string;
  description?: string;
  guideName?: string;
  rating: number;
  duration?: string;
  thumbnail: number[];
  tripSize?: string;
  difficulty?: string;
  activityNames: string[];
  riskNames: string[];
  includedStuffNames: string[];
  logingNames: string[];
  notAllowedStuffNames: string[];
  notSuitableForNames: string[];
  requiredStuffNames: string[];
}

export interface TripGetListInput extends PagedAndSortedResultRequestDto {
}
