import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { TripsComponent } from './trips/trips.component';
import { DestinationsComponent } from './destinations/destinations.component';
import { GuidesComponent } from './guides/guides.component';
import { HelpComponent } from './help/help.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { TripItemComponent } from './trips/trip-item/trip-item.component';
import { TripDetailsComponent } from './trips/trip-details/trip-details.component';
import { RatingStarsComponent } from './Shared/rating-stars/rating-stars.component';
import { TripItemLoadingComponent } from './trips/trip-item-loading/trip-item-loading.component';
import { WishListTripItemLoadingComponent } from './wishlist/wish-list-trip-item-loading/wish-list-trip-item-loading.component';
import { WishListTripItemComponent } from './wishlist/wish-list-trip-item/wish-list-trip-item.component';
import { GuideItemComponent } from './guides/guide-item/guide-item.component';
import { GuideDetailsComponent } from './guides/guide-details/guide-details.component';
import { GuideItemLoadingComponent } from './guides/guide-item-loading/guide-item-loading.component'; 
import { SearchFieldComponent } from './search-field/search-field.component'; 

@NgModule({
  declarations: [
    HomeComponent,
    TripsComponent,
    DestinationsComponent,
    GuidesComponent,
    HelpComponent,
    WishlistComponent, 
    TripItemComponent,
    TripDetailsComponent,
    RatingStarsComponent,
    TripItemLoadingComponent,
    WishListTripItemLoadingComponent,
    WishListTripItemComponent,
    GuideItemComponent,
    GuideDetailsComponent,
    GuideItemLoadingComponent, 
    SearchFieldComponent
  ],
  imports: [
    SharedModule,
    HomeRoutingModule,
    
  ],
})
export class HomeModule { }
