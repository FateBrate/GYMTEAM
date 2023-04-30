import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { LOGIN } from '../endpoints';
import { ILoginResponse } from '../models/login';
import { IUser } from '../models/user';
import { IAuth } from '../models/login';
import {
  COOKIE_USER_DATA,
  TOKEN_DATA,
  routerpath,
} from 'src/app/constants/deafult';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private cookie: CookieService,
    private ruter: Router
  ) {}

  login({ email, lozinka }: Partial<IUser>) {
    try {
      this.httpClient
        .post<ILoginResponse>(`${routerpath}${LOGIN}`, { email, lozinka })
        .subscribe((response) => {
          if (!!response) {
            console.log(response);
            const { korisnik, korisnikId, ...token } =
              response.autentifikacijaToken;
            const cookieSettings = {
              // domain: 'localhost',
              // path: '/',
              // secure: true,
              // expiry: 7,
              domain: 'localhost',
              // path: '/',
              // secure: window.location.protocol === 'https:',
              // expires: new Date(Date.now() + 7 * 24 * 60 * 60 * 1000),
            };
            this.cookie.set(COOKIE_USER_DATA, JSON.stringify(korisnik.id), {
              ...cookieSettings,
            });
            // this.cookie.set(COOKIE_USER_DATA, 'korisnik', {
            //   ...cookieSettings,
            // });
            console.log(this.cookie.get(COOKIE_USER_DATA));

            sessionStorage.setItem(TOKEN_DATA, JSON.stringify(token));
          }
        });
    } catch (error) {
      console.error(error);
      return false;
    }
  }

  setSessionStorage(autentifikacijaToken: Partial<IAuth>) {}
}
