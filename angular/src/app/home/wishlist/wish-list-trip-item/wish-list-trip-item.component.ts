import { Component, Input, OnInit } from '@angular/core';
import { difficultyOptions, durationUnitOptions } from '@proxy';

@Component({
  selector: 'app-wish-list-trip-item',
  templateUrl: './wish-list-trip-item.component.html',
  styleUrls: ['./wish-list-trip-item.component.scss']
})
export class WishListTripItemComponent implements OnInit {
  @Input()
  trip
  constructor() { }

  getEnumDiff(a) {
    return difficultyOptions.find(e => e.value == a).key
  }
  getEnumDuration(a) {
    return durationUnitOptions.find(e => e.value == a).key
  }
  ngOnInit(): void {
  }

}
