import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'; 
import { TripDto, TripService } from '@proxy';

@Component({
  selector: 'app-trip-details',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.scss']
})
export class TripDetailsComponent implements OnInit {
  tripItem: TripDto
  loading = false
  constructor(public tripService: TripService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      this.loading = true
      this.tripService.get(paramMap.get('id')).subscribe(
        e => {
          this.tripItem = e
          this.loading = false
        }
      )
    })

  }

}
