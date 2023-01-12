import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA } from 'src/app/constants/deafult';
import { IUser } from 'src/app/service/models/user';

@Component({
  selector: 'app-admin-info',
  templateUrl: './admin-info.component.html',
  styleUrls: ['./admin-info.component.css'],
})
export class AdminInfoComponent implements OnInit {
  changetype: boolean = true;

  PrikaziSifru() {
    this.changetype = !this.changetype;
  }
  constructor(private cookie: CookieService) {}
  korisnik?: IUser;
  ngOnInit(): void {
    this.korisnik = JSON.parse(this.cookie.get(COOKIE_USER_DATA));
  }
}
