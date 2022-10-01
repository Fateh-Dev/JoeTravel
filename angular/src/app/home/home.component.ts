import { AuthService, PagedResultDto } from '@abp/ng.core';
import { Component, HostListener } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Directive, ElementRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TripDto, TripService } from '@proxy';
import { HomeService } from './home.service';

// @Directive({ selector: 'img' })
// export class LazyImgDirective {
//   constructor({ nativeElement }: ElementRef<HTMLImageElement>) {
//     const supports = 'loading' in HTMLImageElement.prototype;

//     if (supports) {
//       nativeElement.setAttribute('loading', 'lazy');
//     }
//   }
// }
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
  items: TripDto[];

  constructor(
    private oAuthService: OAuthService,
    private authService: AuthService,
    public tripService: TripService,
    public homeService: HomeService
  ) {}

  login() {
    this.authService.navigateToLogin();
  }

  ngOnInit() {
    this.loading = true;
    this.tripService.getHomeList({ maxResultCount: 6, skipCount: 0 }).subscribe(e => {
      this.items = e.items;
      this.a = e.items;
      this.loading = false;
      console.log(e);
    });
  }

  _loading = false;
  a: TripDto[];
  loadMoreTrips() {
    // this.a.concat(this.items);
    // this._loading = true
    // this.tripService.getList({ maxResultCount: 5, skipCount: this.a.totalCount }).subscribe(
    //   e => {
    //     if (e.totalCount > 0) {
    //       this.a.a(...e)
    //       this.items = this.a.slice(this.a.length - 5)
    //     }
    //     this._loading = false
    //     console.log(e)
    //   })
  }

  loadPreviousTrips() {
    // this._loading = true
    // this.tripService.getHomeList({ maxResult: 5, pageSkip: this.a.length - 5 }).subscribe(
    //   e => {
    //     if (e.length > 0) {
    //       this.a.push(...e)
    //       this.items = this.a.splice(this.a.length - 5, 5)
    //     }
    //     this._loading = false
    //     console.log(e)
    //   })
  }
}
