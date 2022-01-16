import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

enableProdMode();
const platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);
