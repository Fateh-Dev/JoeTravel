import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TripDto, TripService } from '@proxy';
import { HomeService } from '../../home.service';

@Component({
  selector: 'app-trip-details',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.scss'],
})
export class TripDetailsComponent implements OnInit {
  tripItem: TripDto;
  loading = false;
  items: TripDto[] = [];
  constructor(
    public tripService: TripService,
    private route: ActivatedRoute,
    public homeService: HomeService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      this.loading = true;
      this.tripService.get(paramMap.get('id')).subscribe(e => {
        this.tripItem = e;
        this.loading = false;
      });
    });

    this.getTrips(this.homeService.searchForm.controls.title.value);
  }
  getTrips(title?: string) {
    this.loading = true;
    console.log(title);
    this.tripService
      .getHomeList({ maxResultCount: 5, skipCount: 0, title: title })
      .subscribe(e => {
        this.items = e.items;
        this.loading = false;
        console.log(e);
      });
  }
}
