import { Component, OnInit, ViewChild } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { difficultyOptions, durationUnitOptions, TripDto, TripService } from '@proxy';
// import { TripService } from '@proxy/app-services';
// import { TripFilter, TripMiniDto } from '@proxy/models';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.scss'],
})
export class WishlistComponent implements OnInit {
  @ViewChild(MatAccordion) accordion: MatAccordion;
  loading = false;
  searchFilter = '';
  items: TripDto[] = [];
  filter: {
    maxResult: 10;
    pageSkip: 0;
  };
  constructor(public tripService: TripService) {}

  getEnumDiff(a) {
    return difficultyOptions.find(e => e.value == a).key;
  }
  getEnumDuration(a) {
    return durationUnitOptions.find(e => e.value == a).key;
  }
  ngOnInit() {
    this.loading = true;
    this.tripService.getHomeList({ maxResultCount: 10, skipCount: 0 }).subscribe(e => {
      this.items = e.items;
      this.loading = false;
      console.log(e);
    });
  }
  loadMoreTrips() {
    // this.filter.pageSkip = this.items.length;
    // this.tripService.getHomeList(this.filter).subscribe(
    //   e => {
    //     this.items = this.items.concat(e)
    //   })
  }
  getTripsByRating(rate) {
    // this.filter.rating = rate
    this.getTrips();
  }
  getTripsByDifficulty(difficulty) {
    // this.filter.difficulty = difficulty
    this.getTrips();
  }
  
  getTrips(title?: string) {
    this.loading = true;
    console.log(title);
    this.tripService
      .getHomeList({ maxResultCount: 100, skipCount: 0, title: title })
      .subscribe(e => {
        this.items = e.items;
        this.loading = false;
        console.log(e);
      });
  }
  searchTrips(event: any) {
    console.log(event);
    this.getTrips(event.title);
  }
}
