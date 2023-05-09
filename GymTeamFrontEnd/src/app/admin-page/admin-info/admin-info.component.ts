import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { DataService } from 'src/app/service/data.service';
import { COOKIE_USER_DATA, routerpath } from 'src/app/constants/deafult';
import { async } from '@angular/core/testing';

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
  uploadedFile: any;
  selectedImage: any;

  PrikaziSifru() {
    this.changetype = !this.changetype;
  }
  constructor(
    private dataService: DataService,
    private cookie: CookieService,
    private httpClient: HttpClient,
    private snackbar: MatSnackBar
  ) {}
  korisnik: any;

  ngOnInit(): void {
    this.loadUser();
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
  getSliku(id: number): string {
    return `${routerpath}/api/Korisnik/GetSlikaById?id=${id}&timestamp=${new Date().getTime()}`;
  }

  onFileChange(event: any) {
    this.showBtn = true;
    this.uploadedFile = event.target.files[0];
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.selectedImage = e.target.result;
    };
    reader.readAsDataURL(this.uploadedFile);
  }
  loadUser(): Promise<void> {
    const cookieValue = this.cookie.get(COOKIE_USER_DATA);
    if (cookieValue) {
      const userId = JSON.parse(cookieValue);
      const observable = this.httpClient.get(
        `${routerpath}/api/Korisnik/GetById?id=${userId}`
      );
      return observable.toPromise().then((res) => {
        if (!!res) {
          this.korisnik = res;
          this.selectedImage = this.getSliku(this.korisnik.id);
        }
      });
    }

    return Promise.resolve();
  }

  async updateProfileImage(): Promise<any> {
    const formData = new FormData();
    formData.append('file', this.uploadedFile);

    const url = `${routerpath}/api/Korisnik/ChangePhoto?id=${this.korisnik.id}`;
    const headers = new HttpHeaders();

    try {
      const res = await this.httpClient
        .put(url, formData, { headers })
        .toPromise();

      if (!!res) {
        this.showBtn = false;

        this.snackbar.open('Uspješno izmjenjena slika profila', 'X', {
          duration: 3000,
          panelClass: ['cacin-caca'],
        });
        await this.dataService.updateKorisnik();
        const korisnik = await this.dataService.updateKorisnik();
        this.selectedImage = this.getSliku(this.korisnik.id);
        this.dataService.user$.next(korisnik);
      }
    } catch (error) {
      console.error(error);
    }
  }
}
