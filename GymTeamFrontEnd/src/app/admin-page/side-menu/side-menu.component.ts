import { Component, OnInit } from '@angular/core';

import { CookieService } from 'ngx-cookie-service';
import { routerpath } from '../../constants/deafult';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { DataService } from 'src/app/service/data.service';
@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css'],
})
export class SideMenuComponent implements OnInit {
  constructor(
    private dataService: DataService,
    private cookie: CookieService,
    private router: Router,
    private httpClient: HttpClient
  ) {}
  isSidebarExpanded: boolean = false;
  korisnik: any;
  slika: any;
  ngOnInit(): void {
    this.loadAll();
  }
  loadAll() {
    this.dataService.user$.subscribe((user) => {
      this.korisnik = user;
      this.slika = this.getSliku(this.korisnik?.id);
    });
  }
  logout() {
    this.httpClient
      .post(routerpath + '/Autentifikacija/Logout', null)
      .subscribe(
        () => {
          console.log('Logged out successfully');
        },
        (error) => {
          console.error('Logout failed:', error);
        }
      );
    this.router.navigate(['login']);
    this.cookie.delete('COOKIE_USER_DATA');
    sessionStorage.clear();
  }

  getSliku(id: number) {
    return `${routerpath}/api/Korisnik/GetSlikaById?id=${id}&timestamp=${new Date().getTime()}`;
  }
  toggleSidebar() {
    this.isSidebarExpanded = !this.isSidebarExpanded;
  }
}
