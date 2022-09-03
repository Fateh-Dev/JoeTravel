import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GuideService } from '@proxy/app-services';
import { GuideDto } from '@proxy/models';

@Component({
  selector: 'app-guide-details',
  templateUrl: './guide-details.component.html',
  styleUrls: ['./guide-details.component.scss']
})
export class GuideDetailsComponent implements OnInit {
  loading = false
  guideItem: GuideDto
  constructor(public guideService: GuideService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      this.loading = true
      this.guideService.getGuideWithDetails(paramMap.get('id')).subscribe(
        e => {
          this.guideItem = e;
          this.loading = false;
        }
      )
    })
  }

}
