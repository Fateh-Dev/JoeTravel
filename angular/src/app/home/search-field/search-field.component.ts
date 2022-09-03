import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { TripFilter } from '@proxy/models';

@Component({
  selector: 'app-search-field',
  templateUrl: './search-field.component.html',
  styleUrls: ['./search-field.component.scss']
})
export class SearchFieldComponent implements OnInit {

  @Output()
  newItemEvent = new EventEmitter<TripFilter>();

  @Input()
  filter: TripFilter
  @Input()
  showDates = true
  myFilter = (d: Date | null): boolean => {
    const day = (d || new Date()).getDay();
    // Prevent Saturday and Sunday from being selected.
    return day !== 0 && day !== 6;
  };
  searchForm = new FormGroup({
    start: new FormControl(new Date()),
    end: new FormControl(new Date(new Date().setMonth(new Date().getMonth() + 1))),
    title: new FormControl('')
  });
  constructor(public datepipe: DatePipe) { }

  ngOnInit(): void {
    this.searchForm.controls.title.setValue(this.filter.title);
    console.log(this.searchForm.value)
  }
  callSearch() {
    // console.log(this.searchForm.value)
    this.newItemEvent.emit(this.searchForm.value)
  }

  events: string[] = [];

  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    // this.events.push(`${type}: ${event.value}`);
  }
}
