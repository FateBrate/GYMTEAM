import { Component, OnInit } from '@angular/core';
import { IAuth } from 'src/app/service/models/login';
import { IUser } from 'src/app/service/models/user';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA } from '../../constants/deafult';
import { Router } from '@angular/router';
@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css'],
})
export class SideMenuComponent implements OnInit {
  constructor(private cookie: CookieService, private router: Router) {}
  korisnik?: IUser;
  ngOnInit(): void {
    this.korisnik = JSON.parse(this.cookie.get(COOKIE_USER_DATA));
  }
  logout() {
    this.router.navigate(['login']);
    this.cookie.delete;
    sessionStorage.clear;
  }
}
