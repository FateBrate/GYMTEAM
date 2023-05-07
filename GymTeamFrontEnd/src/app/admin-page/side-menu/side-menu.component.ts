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

  ngOnInit(): void {
    // this.dataService.getUserUpdatedListener().subscribe((user: any) => {
    //   this.korisnik = user;
    //   console.log('user', user);
    // });
    // this.loadUserData();
    this.allNighz();
  }

  allNighz() {
    // this.dataService.getUserUpdatedListener().subscribe((user: any) => {
    //   console.log(user, 'hahahah');
    //   // this.korisnik = user;
    // });
    this.loadUserData();
  }

  logout() {
    this.router.navigate(['login']);
    this.cookie.delete;
    sessionStorage.clear();
  }
  // loadUserData() {
  //   const cookieValue = this.cookie.get(COOKIE_USER_DATA);
  //   if (cookieValue) {
  //     let userId = JSON.parse(cookieValue);
  //     this.httpClient
  //       .get(`${routerpath}/api/Korisnik/GetById?id=${userId}`)
  //       .subscribe((res) => {
  //         if (!!res) {
  //           this.korisnik = res;
  //         }
  //       });
  //   }
  // }
  async loadUserData() {
    this.dataService.userUpdated.emit();
    console.log('ja ba');
    this.korisnik = await this.dataService.loadUserData();
    console.log(this.korisnik, 'halo');
    console.log(this.korisnik, 'sidemenu loadUserData');
    const cookieValue = this.cookie.get(COOKIE_USER_DATA);
    if (cookieValue) {
      let userId = JSON.parse(cookieValue);
      this.httpClient
        .get(`${routerpath}/api/Korisnik/GetById?id=${userId}`)
        .subscribe((res: any) => {
          if (!!res) {
            this.korisnik = res;
          }
        });
    }
  }
  getSliku(id: number) {
    return `${routerpath}/api/Korisnik/GetSlikaById?id=${id}`;
  }
}
