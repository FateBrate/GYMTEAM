import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CookieService } from 'ngx-cookie-service';

import {
  COOKIE_USER_DATA,
  TOKEN_DATA,
  routerpath,
} from 'src/app/constants/deafult';
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
  newKorisnik: any;
  showBtn: boolean = false;
  editUser: any;
  photo: any;
  newPhotoString: any;
  NewPhotoFile: any;
  PrikaziSifru() {
    this.changetype = !this.changetype;
  }
  constructor(
    private cookie: CookieService,
    private httpClient: HttpClient,
    private snackbar: MatSnackBar
  ) {}
  korisnik: any;
  ngOnInit(): void {
    this.loadUser();
    this.photo = this.getSliku(this.korisnik?.id);
  }
  loadUser() {
    const cookieValue = this.cookie.get(COOKIE_USER_DATA);
    if (cookieValue) {
      let userId = JSON.parse(cookieValue);
      this.httpClient
        .get(`${routerpath}/api/Korisnik/GetById?id=${userId}`)
        .subscribe((res) => {
          if (!!res) {
            this.korisnik = res;
          }
        });
    }
  }
  editData() {
    this.enableEdit = !this.enableEdit;
    if (this.enableEdit == true) this.buttonName = 'Spremi';
    else this.buttonName = 'Uredi podatke';
    this.counter++;
    console.log(this.counter);
    if (this.counter == 3) {
      this.saveChanges();
    }
  }
  saveChanges() {
    const url = routerpath + '/api/Korisnik?id=';
    this.editUser = {
      ime: this.korisnik?.ime,
      email: this.korisnik?.email,
      prezime: this.korisnik?.prezime,
      lozinka: this.korisnik?.lozinka,
      brojTelefona: this.korisnik?.brojTelefona,
    };
    if ((this.changeData = true)) {
    }

    if (!this.enableEdit && !!this.changeData) {
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
  getSliku(id: number) {
    return `${routerpath}/api/Korisnik/GetSlikaById?id=${id}`;
  }
  onFileChange(event: any) {
    this.showBtn = true;
    // const file = event.target.files[0];
    // const reader = new FileReader();
    // reader.readAsDataURL(file);
    // reader.onload = () => {
    //   this.newPhotoString = reader.result?.toString().split(',')[1];
    //   this.NewPhotoFile = reader.result;
    //   if (reader.result !== null) {
    //     const blob = new Blob([reader.result], { type: file.type });
    //     this.NewPhotoFile = blob;
    //   }
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.NewPhotoFile = reader.result;
      };
    }
  }

  updateProfileImage() {
    // const url = `${routerpath}/api/Korisnik/ChangePhoto?id=${this.korisnik.id}`;
    // const formData = new FormData();
    // formData.append('file', this.NewPhotoFile, this.NewPhotoFile.name);
    // const headers = new HttpHeaders().set(
    //   'Content-Type',
    //   'multipart/form-data/json'
    // );
    // console.log(this.newPhotoString);
    // console.log(this.NewPhotoFile);
    // this.httpClient.put(url, formData, { headers }).subscribe((res) => {
    //   if (!!res) {
    //     console.log('proslo');
    //   }
    // });
    const url = `${routerpath}/api/Korisnik/ChangePhoto?id=${this.korisnik.id}`;
    const body = this.NewPhotoFile;
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    console.log(this.newPhotoString);
    console.log(this.NewPhotoFile);
    this.httpClient.put(url, body, { headers }).subscribe((res) => {
      if (!!res) {
        console.log('proslo');
      }
    });
  }
}
