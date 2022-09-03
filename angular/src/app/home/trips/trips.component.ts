import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { difficultyOptions, durationUnitOptions } from '@proxy';
import { TripService } from '@proxy/app-services';
import { TripFilter, TripMiniDto } from '@proxy/models'; 

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.scss']
})
export class TripsComponent implements OnInit {
  filter: TripFilter = {
    maxResult: 12,
    pageSkip: 0,
  }
  loading = false;
  items: TripMiniDto[] = [];
  searchFilter = '';
  constructor(
    public tripService: TripService, private route: ActivatedRoute) { }

  getEnumDiff(a) {
    return difficultyOptions.find(e => e.value == a).key
  }
  getEnumDuration(a) {
    return durationUnitOptions.find(e => e.value == a).key
  }
  ngOnInit(): void {

    this.route.paramMap.subscribe(paramMap => {
      if (paramMap.get('title')) {
        this.filter.title = paramMap.get('title');

        console.log(this.filter)
      }
      this.loading = true
      this.tripService.getHomeList(this.filter).subscribe(
        e => {
          this.items = e;
          this.loading = false
        })
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
  getTrips() {
    this.loading = true
    this.filter.pageSkip = 0;
    this.tripService.getHomeList(this.filter).subscribe(
      e => {
        this.items = e;
        this.loading = false
      })
  }
  searchTrips(event: TripFilter) {
    this.filter.title = event.title
    this.getTrips();
  }

}
