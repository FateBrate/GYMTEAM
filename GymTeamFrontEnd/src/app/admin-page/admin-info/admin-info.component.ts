import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA, TOKEN_DATA } from 'src/app/constants/deafult';
import { IUser } from 'src/app/service/models/user';

@Component({
  selector: 'app-admin-info',
  templateUrl: './admin-info.component.html',
  styleUrls: ['./admin-info.component.css'],
})
export class AdminInfoComponent implements OnInit {
  changetype: boolean = true;
  enableEdit: boolean = false;
  buttonName: string = 'Uredi podatke';
  changeData: boolean = false;
  api_url: string = 'http://localhost:5164';
  counter: number = 1;
  userId: number = 0;
  // ime: string = '';
  // prezime: string = '';
  // lozinka: string = '';
  // brojTelefona: string = '';
  // email: string = '';
  newKorisnik: any;

  editUser: any;
  PrikaziSifru() {
    this.changetype = !this.changetype;
  }
  constructor(
    private cookie: CookieService,
    private httpClient: HttpClient,
    private snackbar: MatSnackBar
  ) {}
  korisnik?: IUser;
  ngOnInit(): void {
    this.loadUser();
  }
  loadUser() {
    this.korisnik = JSON.parse(this.cookie.get(COOKIE_USER_DATA));
    if (this.korisnik != null) {
      this.userId = this.korisnik.id;
    }
  }
  editData() {
    this.enableEdit = !this.enableEdit;
    if (this.enableEdit == true) this.buttonName = 'Spremi';
    else this.buttonName = 'Uredi podatke';
    this.counter++;
    console.log('radi');
    console.log(this.counter);
    if (this.counter == 3) {
      this.saveChanges();
    }
  }
  saveChanges() {
    const url = this.api_url + '/api/Korisnik?id=';
    console.log('uslo');
    this.editUser = {
      ime: this.korisnik?.ime,
      email: this.korisnik?.email,
      prezime: this.korisnik?.prezime,
      lozinka: this.korisnik?.lozinka,
      brojTelefona: this.korisnik?.brojTelefona,
    };
    if ((this.changeData = true)) {
      console.log('promjena');
    }

    if (!this.enableEdit && !!this.changeData) {
      console.log('updateovano');
      const cookieSettings = {
        domain: 'localhost',
        path: '/',
        secure: true,
        expiry: 7,
      };
      this.httpClient
        .put(`${url}${this.userId}`, this.editUser)
        .subscribe((res) => {
          if (!!res) {
            this.newKorisnik = res;
            console.log(res);
            this.cookie.delete(COOKIE_USER_DATA);
            sessionStorage.clear();
            this.cookie.set(
              COOKIE_USER_DATA,
              JSON.stringify(this.newKorisnik),
              {
                ...cookieSettings,
              }
            );
          }
          this.loadUser();
          this.counter = 1;
        });
    }
    this.snackbar.open('Uspješno promjenjeni podaci', 'X', {
      duration: 3000,
      panelClass: ['cacin-caca'],
    });
  }
}
