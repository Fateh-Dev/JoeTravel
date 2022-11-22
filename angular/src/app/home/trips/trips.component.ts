import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { difficultyOptions, durationUnitOptions, TripDto, TripService } from '@proxy';
import { HomeService } from '../home.service';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.scss'],
})
export class TripsComponent implements OnInit {
  loading = false;
  items: TripDto[] = [];
  constructor(
    public tripService: TripService,
    public homeService: HomeService,
    private route: ActivatedRoute
  ) {}

  getEnumDiff(a) {
    return difficultyOptions.find(e => e.value == a).key;
  }
  getEnumDuration(a) {
    return durationUnitOptions.find(e => e.value == a).key;
  }
  ngOnInit(): void {
    this.getTrips(this.homeService.searchForm.controls.title.value);
  }

  // loadMoreTrips() {
  //   this.filter.pageSkip = this.items.length;
  //   this.tripService.getHomeList(this.filter).subscribe(e => {
  //     this.items = this.items.concat(e);
  //   });
  // }
  getTripsByRating(rate) {
    console.log(rate)
  }
  getTripsByDifficulty(difficulty) {
    // this.filter.diff
    console.log(difficulty)
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
