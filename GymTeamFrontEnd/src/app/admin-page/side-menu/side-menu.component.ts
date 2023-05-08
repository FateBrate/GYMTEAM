import {
  Component,
  EventEmitter,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { IAuth } from 'src/app/service/models/login';
import { IUser } from 'src/app/service/models/user';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA, routerpath } from '../../constants/deafult';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
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
    this.router.navigate(['login']);
    this.cookie.delete;
    sessionStorage.clear();
  }

  getSliku(id: number) {
    return `${routerpath}/api/Korisnik/GetSlikaById?id=${id}&timestamp=${new Date().getTime()}`;
  }
}
