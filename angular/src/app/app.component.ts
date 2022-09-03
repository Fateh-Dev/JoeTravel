import { AuthService, ConfigStateService } from '@abp/ng.core';
import { Component, HostListener } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
@Component({
  selector: 'app-root',
  templateUrl: "app.component.html",
})
export class AppComponent {
  /**
   *
   */
  constructor(public authService: AuthService, public configStatService: ConfigStateService) {


  }
  logOut() {
    this.authService.logout({ redirectUrl: '' }).subscribe(e => console.log(e))
  }
  @HostListener('window:scroll', ['$event'])
  onWindowScroll() {

    // else {
    //   element.classList.remove('bg-white/30');
    //   element.classList.remove('backdrop-blur-lg');
    //   element.classList.add('bg-white/0');
    //   element.classList.remove('shadow-md');
    // }
  }

  ngOnInit() {
    // console.log(this.configStatService.getOne('currentUser').isAuthenticated)
    let element = document.querySelector('.headerToolbar') as HTMLElement;
    // if (window.pageYOffset > 5) {
    // element.classList.remove('bg-white/0');
    element.classList.add('bg-white/70');
    element.classList.add('backdrop-blur-lg');
    element.classList.add('shadow-md');
    // }
  }
}
