import { Component, OnInit } from '@angular/core';
import { IAuth } from 'src/app/service/models/login';
import { IUser } from 'src/app/service/models/user';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA } from '../../constants/deafult';
@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css'],
})
export class SideMenuComponent implements OnInit {
  constructor(private cookie: CookieService) {}
  korisnik?: IUser;
  ngOnInit(): void {
    this.korisnik = JSON.parse(this.cookie.get(COOKIE_USER_DATA));
    console.log(this.korisnik);
  }
}
