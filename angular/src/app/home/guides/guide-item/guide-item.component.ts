import { Component, Input, OnInit } from '@angular/core';
import { GuideDto } from '@proxy/models';

@Component({
  selector: 'app-guide-item',
  templateUrl: './guide-item.component.html',
  styleUrls: ['./guide-item.component.scss']
})
export class GuideItemComponent implements OnInit {
  @Input()
  guide: GuideDto
  constructor() { }

  ngOnInit(): void {
  }

}
