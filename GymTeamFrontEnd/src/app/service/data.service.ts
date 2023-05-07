import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

import { Subject } from 'rxjs';
import { COOKIE_USER_DATA, routerpath } from '../constants/deafult';
@Injectable({
  providedIn: 'root',
})
export class DataService {
  public userUpdated = new EventEmitter<any>();

  constructor(
    private httpClient: HttpClient,
    private cookieService: CookieService
  ) {}
  korisnik: any;
  getUserUpdatedListener() {
    // console.log('servis');
    return this.userUpdated.asObservable();
  }

  async loadUserData() {
    console.log('service');
    const cookieValue = this.cookieService.get(COOKIE_USER_DATA);
    if (cookieValue) {
      let userId = JSON.parse(cookieValue);
      await this.httpClient
        .get(`${routerpath}/api/Korisnik/GetById?id=${userId}`)
        .toPromise()
        .then((res) => {
          this.korisnik = res;
          // this.userUpdated.next(res);
          console.log('dobavljam', this.korisnik);
          return this.korisnik;
        });
    }
  }
}
