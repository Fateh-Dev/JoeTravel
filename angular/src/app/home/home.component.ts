import { AuthService } from '@abp/ng.core';
import { Component, HostListener } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

import { Directive, ElementRef } from '@angular/core';
import { Trip, TripDto, TripMiniDto } from '@proxy/models';
import { TripService } from '@proxy/app-services/trip.service';
import { FormControl, FormGroup } from '@angular/forms';

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
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  get hasLoggedIn(): boolean {
    return this.oAuthService.hasValidAccessToken();
  }
  loading = false;
  items: TripMiniDto[] = [];

  searchForm = new FormGroup({
    start: new FormControl(new Date()),
    end: new FormControl(new Date()),
    title: new FormControl('')
  });

  constructor(
    private oAuthService: OAuthService,
    private authService: AuthService,
    public tripService: TripService) {

  }

  login() {
    this.authService.navigateToLogin();
  }

  ngOnInit() {
    this.loading = true
    this.tripService.getHomeList({ maxResult: 5, pageSkip: this.items.length }).subscribe(
      e => {
        this.items = e;
        this.a = e
        this.loading = false
        console.log(e)
      })
  }

  _loading = false;
  a: TripMiniDto[] = []
  loadMoreTrips() {
    // this.a.concat(this.items);
    this._loading = true
    this.tripService.getHomeList({ maxResult: 5, pageSkip: this.a.length }).subscribe(
      e => {
        if (e.length > 0) {
          this.a.push(...e)
          this.items = this.a.slice(this.a.length - 5)
        }
        this._loading = false
        console.log(e)
      })
  }

  loadPreviousTrips() {
    this._loading = true
    this.tripService.getHomeList({ maxResult: 5, pageSkip: this.a.length - 5 }).subscribe(
      e => {
        if (e.length > 0) {
          this.a.push(...e)
          this.items = this.a.splice(this.a.length - 5, 5)
        }
        this._loading = false
        console.log(e)
      })
  }
}
