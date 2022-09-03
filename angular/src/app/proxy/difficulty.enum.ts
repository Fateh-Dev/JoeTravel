import { mapEnumToOptions } from '@abp/ng.core';

export enum Difficulty {
  Easy = 0,
  Hard = 1,
}

export const difficultyOptions = mapEnumToOptions(Difficulty);
