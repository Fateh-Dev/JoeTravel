import { mapEnumToOptions } from '@abp/ng.core';

export enum Gender {
  Man = 0,
  Woman = 1,
}

export const genderOptions = mapEnumToOptions(Gender);
