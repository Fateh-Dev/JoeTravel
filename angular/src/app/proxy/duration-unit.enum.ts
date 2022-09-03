import { mapEnumToOptions } from '@abp/ng.core';

export enum DurationUnit {
  Hour = 0,
  Day = 1,
}

export const durationUnitOptions = mapEnumToOptions(DurationUnit);
