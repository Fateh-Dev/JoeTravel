import { Component, OnInit, ViewChild } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { difficultyOptions, durationUnitOptions } from '@proxy';
import { TripService } from '@proxy/app-services';
import { TripFilter, TripMiniDto } from '@proxy/models'; 

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.scss']
})
export class WishlistComponent implements OnInit {

  @ViewChild(MatAccordion) accordion: MatAccordion;
  loading = false;
  searchFilter = '';
  items: TripMiniDto[] = [];
  filter: TripFilter = {
    maxResult: 10,
    pageSkip: 0
  }
  constructor(
    public tripService: TripService) {

  }

  getEnumDiff(a) {
    return difficultyOptions.find(e => e.value == a).key
  }
  getEnumDuration(a) {
    return durationUnitOptions.find(e => e.value == a).key
  }
  ngOnInit() {
    this.loading = true
    this.tripService.getHomeList(this.filter).subscribe(
      e => {
        this.items = e;
        this.loading = false
      })
  }
  loadMoreTrips() {
    this.filter.pageSkip = this.items.length;
    this.tripService.getHomeList(this.filter).subscribe(
      e => {
        this.items = this.items.concat(e)
      })
  }
  getTripsByRating(rate) {
    this.filter.rating = rate
    this.getTrips()
  }
  getTripsByDifficulty(difficulty) {
    this.filter.difficulty = difficulty
    this.getTrips()
  } 
  searchTrips(event: TripFilter) {
    this.filter.title = event.title
    this.getTrips();
  }
  getTrips() {
    this.loading = true
    this.filter.pageSkip = 0;
    // console.log(this.filter)
    this.tripService.getHomeList(this.filter).subscribe(
      e => {
        this.items = e;
        this.loading = false
      })
  }
}
