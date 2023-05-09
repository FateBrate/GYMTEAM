import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IUser } from 'src/app/service/models/user';
import { Uloga } from 'src/app/service/models/role';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AdminEmployeeComponent } from '../../admin-employee/./admin-employee.component';
import { routerpath } from 'src/app/constants/deafult';
@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css'],
})
export class AddUserComponent implements OnInit {
  forma: FormGroup = new FormGroup({
    ime: new FormControl('', [
      Validators.required,
      Validators.pattern('^[a-zA-Z ]*$'),
    ]),
    prezime: new FormControl('', [
      Validators.required,
      Validators.pattern('^[a-zA-Z ]*$'),
    ]),
    brojTelefona: new FormControl('', [
      Validators.required,
      Validators.pattern('^[0-9]*$'),
    ]),
    email: new FormControl('', [Validators.required, Validators.email]),
    lozinka: new FormControl('', Validators.required),
    roleId: new FormControl(Uloga.GuestUser, Validators.required),
    datumRodjenja: new FormControl('', Validators.required),
  });
  role = Uloga;
  selected: boolean = false;
  photo: any;
  fileChange: boolean = false;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogref: MatDialogRef<AddUserComponent>,
    public popUpRef: MatDialogRef<AdminEmployeeComponent>,
    private klijent: HttpClient,
    private snackbar: MatSnackBar
  ) {}

  ngOnInit() {}
  onFileChange(event: any) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.photo = reader.result;
      };
    }
  }
  saveUser(data: Partial<IUser>) {
    if (this.forma.valid) {
      const objekat = { lokacijaId: 0, slika: this.photo };
      data = { ...data, ...objekat };
      this.klijent
        .post(`${routerpath}/api/Korisnik`, { ...data })
        .subscribe((response) => {
          if (!!response) {
            this.snackbar.open('Korisnik uspjesno dodan', 'X', {
              duration: 3000,
              panelClass: ['cacin-caca'],
            });
            this.dialogref.close();
            return;
          } else {
            this.snackbar.open('Greska kod dodavanja', 'X', {
              duration: 3000,
              panelClass: ['error-snack'],
            });
            return;
          }
        });
    } else {
      this.snackbar.open('Unesite svako polje', 'X', {
        duration: 3000,
        panelClass: ['error-snack'],
      });
    }
  }
}
