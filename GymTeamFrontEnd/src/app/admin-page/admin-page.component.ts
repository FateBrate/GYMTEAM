import { Component, OnInit } from '@angular/core';
import { IUser } from '../service/models/user';
import { IAuth } from '../service/models/login';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA } from '../constants/deafult';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css'],
})
export class AdminPageComponent implements OnInit {
  constructor(private cookie: CookieService) {}
  korisnik?: IUser;
  ngOnInit(): void {
    this.korisnik = JSON.parse(this.cookie.get(COOKIE_USER_DATA));
    console.log(this.korisnik);
  }
}
