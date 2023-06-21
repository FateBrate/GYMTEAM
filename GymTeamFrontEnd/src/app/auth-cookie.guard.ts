import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthCookieGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean | UrlTree {
    const cookieValue = this.getCookieValue('COOKIE_USER_DATA'); // Replace 'your-cookie-name' with the actual name of your cookie
    if (cookieValue) {
      return true;
    } else {
      return this.router.parseUrl('/error-page');
    }
  }

  private getCookieValue(name: string): string {
    const cookie = document.cookie
      .split(';')
      .find((cookie) => cookie.trim().startsWith(name + '='));
    if (cookie) {
      return cookie.split('=')[1];
    } else {
      return '';
    }
  }
}
