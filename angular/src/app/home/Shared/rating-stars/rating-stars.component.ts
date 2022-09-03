import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-rating-stars',
  templateUrl: './rating-stars.component.html',
  styleUrls: ['./rating-stars.component.scss']
})
export class RatingStarsComponent implements OnInit {
  @Input()
  rate;
  items = []
  constructor() {
  }

  ngOnInit(): void {
    while (this.items.length < 5) {
      if (this.items.length < this.rate) this.items.push('solid')
      else this.items.push('regular')
    }
  }

}
