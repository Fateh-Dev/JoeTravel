import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { GuideProfileComponent } from './guide-profile/guide-profile.component';
// import { SharedModule } from '../shared/shared.module';
import { GuideHomeComponent } from './guide-home/guide-home.component';
import { CreateTripComponent } from './create-trip/create-trip.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/material.module';
import { MatFileUploadModule } from 'angular-material-fileupload';


@NgModule({
  declarations: [
    GuideProfileComponent,
    GuideHomeComponent,
    CreateTripComponent],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    ReactiveFormsModule, MaterialModule, MatFileUploadModule
  ]
})
export class ProfileModule { }
