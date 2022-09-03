import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { DestinationsComponent } from './home/destinations/destinations.component';
import { GuideDetailsComponent } from './home/guides/guide-details/guide-details.component';
import { GuidesComponent } from './home/guides/guides.component';
import { HelpComponent } from './home/help/help.component';
import { HomeComponent } from './home/home.component';
import { TripDetailsComponent } from './home/trips/trip-details/trip-details.component';
import { TripsComponent } from './home/trips/trips.component';
import { WishlistComponent } from './home/wishlist/wishlist.component';
import { LoginComponent } from './login/login.component';
import { GuideHomeComponent } from './profile/guide-home/guide-home.component';

const routes: Routes = [
  {
    path: 'auth',
    // loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
    component: LoginComponent
  },
  {
    path: '',
    component: AppComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'trips', component: TripsComponent },
      { path: 'trips/:title', component: TripsComponent },
      { path: 'trips/trip-details/:id', component: TripDetailsComponent },
      { path: 'destinations', component: DestinationsComponent },
      { path: 'guides', component: GuidesComponent },
      { path: 'guides/guide-details/:id', component: GuideDetailsComponent },
      { path: 'wishlist', component: WishlistComponent },
      { path: 'help', component: HelpComponent }, {
        path: 'account',
        loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
      },
      {
        path: 'profile',
        component: GuideHomeComponent,
        loadChildren: () =>
          import('./profile/profile.module').then((m) => m.ProfileModule),
      },
      {
        path: 'identity',
        loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
      },
      {
        path: 'tenant-management',
        loadChildren: () =>
          import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
      },
      {
        path: 'setting-management',
        loadChildren: () =>
          import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule { }
