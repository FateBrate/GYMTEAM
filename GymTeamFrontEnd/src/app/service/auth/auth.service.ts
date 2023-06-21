import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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
import { Observable, catchError, map, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient, private cookie: CookieService) {}

  // login({ email, lozinka }: Partial<IUser>) {
  //   try {
  //     this.httpClient
  //       .post<ILoginResponse>(`${routerpath}${LOGIN}`, { email, lozinka })
  //       .subscribe((response) => {
  //         if (!!response) {
  //           const { korisnik, korisnikId, ...token } =
  //             response.autentifikacijaToken;
  //           const cookieSettings = {
  //             domain: 'localhost',
  //           };
  //           this.cookie.set(COOKIE_USER_DATA, JSON.stringify(korisnik.id), {
  //             ...cookieSettings,
  //           });

  //           sessionStorage.setItem(TOKEN_DATA, JSON.stringify(token));
  //           return true;
  //         }
  //       });
  //   } catch (error) {
  //     console.error(error);
  //     return false;
  //   }
  // }
  login({ email, lozinka }: Partial<IUser>): Observable<boolean> {
    try {
      return this.httpClient
        .post<ILoginResponse>(`${routerpath}${LOGIN}`, { email, lozinka })
        .pipe(
          map((response) => {
            if (!!response) {
              const { korisnik, korisnikId, ...token } =
                response.autentifikacijaToken;
              const cookieSettings = {
                domain: 'localhost',
              };
              this.cookie.set(COOKIE_USER_DATA, JSON.stringify(korisnik.id), {
                ...cookieSettings,
              });
              sessionStorage.setItem(TOKEN_DATA, JSON.stringify(token));
              return true;
            }
            return false;
          }),
          catchError((error) => {
            console.error(error);
            return of(false);
          })
        );
    } catch (error) {
      console.error(error);
      return of(false);
    }
  }
  setSessionStorage(autentifikacijaToken: Partial<IAuth>) {}
}
