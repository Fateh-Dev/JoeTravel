import { AuthService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  username: string;
  password: string;
  constructor(public authService: AuthService,) { }

  ngOnInit(): void {
  }
  login() {
    console.log({ username: this.username, password: this.password, redirectUrl: '', rememberMe: true })
    // this.authService.login({ username: this.username, password: this.password, redirectUrl: '', rememberMe: true }).subscribe(e => console.log(e))
  }
}
