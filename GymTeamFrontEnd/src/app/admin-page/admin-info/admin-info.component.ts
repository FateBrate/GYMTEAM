import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CookieService } from 'ngx-cookie-service';
import { DataService } from 'src/app/service/data.service';
import { COOKIE_USER_DATA, routerpath } from 'src/app/constants/deafult';

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
  counter: number = 1;
  userId: number = 0;
  newKorisnik: any;
  showBtn: boolean = false;
  editUser: any;
  photo: any;
  uploadedFile: any;
  selectedImage: any;

  constructor(
    private dataService: DataService,
    private cookie: CookieService,
    private httpClient: HttpClient,
    private snackbar: MatSnackBar
  ) {}
  korisnik: any;
  loadUser(): Promise<void> {
    const cookieValue = this.cookie.get(COOKIE_USER_DATA);
    if (cookieValue) {
      this.userId = JSON.parse(cookieValue);
      const observable = this.httpClient.get(
        `${routerpath}/api/Korisnik/GetById?id=${this.userId}`
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

  ngOnInit(): void {
    this.loadUser();
  }

  editData() {
    this.enableEdit = !this.enableEdit;
    if (this.enableEdit == true) this.buttonName = 'Spremi';
    else this.buttonName = 'Uredi podatke';
    this.counter++;
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
      };
      this.httpClient
        .put(`${url}${this.userId}`, this.editUser)
        .subscribe((res) => {
          if (!!res) {
            this.newKorisnik = res;
            this.dataService.updateKorisnik();
            this.dataService.user$.next(this.newKorisnik);
          }
          this.loadUser();
          this.counter = 1;
        });
    }
    this.snackbar.open('Uspješno promjenjeni podaci', 'X', {
      duration: 3000,
      panelClass: ['success-snack'],
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
          panelClass: ['success-snack'],
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
  PrikaziSifru() {
    this.changetype = !this.changetype;
  }
}
