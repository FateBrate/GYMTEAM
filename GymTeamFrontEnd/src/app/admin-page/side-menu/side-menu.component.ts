import { Component, OnInit } from '@angular/core';
import { IAuth } from 'src/app/service/models/login';
import { IUser } from 'src/app/service/models/user';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA, routerpath } from '../../constants/deafult';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css'],
})
export class SideMenuComponent implements OnInit {
  constructor(
    private cookie: CookieService,
    private router: Router,
    private httpClient: HttpClient
  ) {}
  korisnik: any;
  ngOnInit(): void {
    const cookieValue = this.cookie.get(COOKIE_USER_DATA);
    if (cookieValue) {
      let userId = JSON.parse(cookieValue);
      this.httpClient
        .get(`${routerpath}/api/Korisnik/GetById?id=${userId}`)
        .subscribe((res) => {
          if (!!res) {
            this.korisnik = res;
          }
        });
    }
  }
  logout() {
    this.router.navigate(['login']);
    this.cookie.delete;
    sessionStorage.clear;
  }
  getSliku(id: number) {
    return `${routerpath}/api/Korisnik/GetSlikaById?id=${id}`;
  }
}
