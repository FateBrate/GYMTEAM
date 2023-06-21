import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA, routerpath } from '../constants/deafult';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css'],
})
export class AdminPageComponent implements OnInit {
  constructor(private cookie: CookieService, private httpClient: HttpClient) {}
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
}
