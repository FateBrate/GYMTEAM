import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { LOGIN } from '../endpoints';
import { ILoginResponse } from '../models/login';
import { IUser } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  api_url:string = 'http://localhost:5164'
  constructor(private httpClient:HttpClient,private cookie:CookieService) { }

  login({email,lozinka}:Partial<IUser>){
    try {
      this.httpClient.post<ILoginResponse>(`${this.api_url}${LOGIN}`,{email,lozinka})
      .subscribe((response) => {
        if(!!response)
          {
            const { korisnik } = response.autentifikacijaToken;
             this.setFeCookie(korisnik);
          }
          return true;
      })
    } catch (error) {
      console.error(error);
      return false;
    }
    return true;
  }

  setFeCookie(korisnik:Partial<IUser>){
    this.cookie.set('KORISNIK_PODACI',JSON.stringify(korisnik));
  }
}
