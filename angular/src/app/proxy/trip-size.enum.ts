import { mapEnumToOptions } from '@abp/ng.core';

export enum TripSize {
  Small = 0,
  Medium = 1,
}

export const tripSizeOptions = mapEnumToOptions(TripSize);
