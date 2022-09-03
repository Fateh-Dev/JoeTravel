import { mapEnumToOptions } from '@abp/ng.core/public-api';
import { Component, Input, OnInit } from '@angular/core';
import { difficultyOptions, durationUnitOptions } from '@proxy';
import { Trip, TripDto, TripMiniDto } from '@proxy/models';
import { Directive, ElementRef } from '@angular/core';

@Directive({ selector: 'img' })
export class LazyImgDirective {
  constructor({ nativeElement }: ElementRef<HTMLImageElement>) {
    const supports = 'loading' in HTMLImageElement.prototype;

    if (supports) {
      nativeElement.setAttribute('loading', 'lazy');
    }
  }
}
@Component({
  selector: 'app-trip-item',
  templateUrl: './trip-item.component.html',
  styleUrls: ['./trip-item.component.scss']
})
export class TripItemComponent implements OnInit {
  @Input()
  trip: TripMiniDto
  @Input()
  loading

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
