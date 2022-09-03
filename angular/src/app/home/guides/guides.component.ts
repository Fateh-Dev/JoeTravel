import { Component, OnInit } from '@angular/core';
import { GuideService, TripService } from '@proxy/app-services';
import { GuideDto } from '@proxy/models';

@Component({
  selector: 'app-guides',
  templateUrl: './guides.component.html',
  styleUrls: ['./guides.component.scss']
})
export class GuidesComponent implements OnInit {
  loading = false;
  items: GuideDto[] = [];
  constructor(
    public guideService: GuideService) {

  }
  ngOnInit(): void {
    this.loading = true
    this.guideService.getList({ maxResultCount: 20 }).subscribe(
      e => {
        this.items = e.items;
        this.loading = false
      })
  }

}
