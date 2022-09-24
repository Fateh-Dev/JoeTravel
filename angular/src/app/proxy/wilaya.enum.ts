import { mapEnumToOptions } from '@abp/ng.core';

export enum Wilaya {
  Undefined = 0,
  Adrar = 1,
  Chlef = 2,
  Laghouat = 3,
  Oum_El_Bouaghi = 4,
  Batna = 5,
  Bejaia = 6,
  Biskra = 7,
  Bechar = 8,
  Blida = 9,
  Bouira = 10,
}

export const wilayaOptions = mapEnumToOptions(Wilaya);
