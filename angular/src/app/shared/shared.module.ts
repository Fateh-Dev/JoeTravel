import { CoreModule } from '@abp/ng.core';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatSliderModule } from '@angular/material/slider';
import { MaterialModule } from './material.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [],
  imports: [
    CoreModule,
    BrowserModule,
    CommonModule,
    RouterModule,
    ThemeSharedModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  exports: [
    CoreModule,
    ThemeSharedModule,
    CommonModule,
    RouterModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    BrowserModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  providers: []
})
export class SharedModule { }
