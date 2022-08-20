import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Travel',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44387',
    redirectUri: baseUrl,
    clientId: 'Travel_App',
    responseType: 'code',
    scope: 'offline_access Travel',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44387',
      rootNamespace: 'Joe.Travel',
    },
  },
} as Environment;
