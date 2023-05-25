import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

import { BehaviorSubject } from 'rxjs';
import { COOKIE_USER_DATA, routerpath } from '../constants/deafult';
@Injectable({
  providedIn: 'root',
})
export class DataService {
  private prosliejdi = new BehaviorSubject<any>(null);
  public user$ = this.prosliejdi;
  constructor(
    private httpClient: HttpClient,
    private cookieService: CookieService
  ) {
    this.loadUserData();
  }
  korisnik: any;
  getUserUpdatedListener() {
    return this.prosliejdi.asObservable();
  }

  async loadUserData() {
    const cookieValue = this.cookieService.get(COOKIE_USER_DATA);
    if (cookieValue) {
      let userId = JSON.parse(cookieValue);
      this.httpClient
        .get(`${routerpath}/api/Korisnik/GetById?id=${userId}`)
        .subscribe((res: any) => {
          if (!!res) {
            this.korisnik = res;
            this.prosliejdi.next(res);
          }
        });
    }
  }
  async updateKorisnik() {
    await this.loadUserData();
  }
}
