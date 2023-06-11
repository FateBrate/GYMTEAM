import { Component, Inject, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IUser } from 'src/app/service/models/user';
import { Uloga } from 'src/app/service/models/role';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AdminEmployeeComponent } from '../../admin-employee/./admin-employee.component';
import { routerpath } from 'src/app/constants/deafult';
import { take, timer } from 'rxjs';
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
  isLoading: boolean = false;
  role = Uloga;
  selected: boolean = false;
  photo: any;
  photoshow: any;
  fileChange: boolean = false;
  randomId: string = '';
  passwordStrength: any;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogref: MatDialogRef<AddUserComponent>,
    public popUpRef: MatDialogRef<AdminEmployeeComponent>,
    private klijent: HttpClient,
    private snackbar: MatSnackBar
  ) {
    this.randomId = Math.random().toString(36).substring(2);
  }

  ngOnInit() {}

  onFileChange(event: any) {
    const reader = new FileReader();
    this.fileChange = true;
    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = (e: any) => {
        this.photoshow = e.target.result;
        this.photo = reader.result;
      };
    }
  }
  checkPasswordStrength(control: AbstractControl): void {
    const password: string = control.value;

    this.passwordStrength = '';

    if (password.length < 8) {
      this.passwordStrength = 'Weak';
    } else if (password.length < 12) {
      this.passwordStrength = 'Medium';
    } else {
      this.passwordStrength = 'Strong';
    }
  }
  saveUser(data: Partial<IUser>) {
    if (this.forma.valid) {
      const objekat = { lokacijaId: 0, slika: this.photo };
      data = { ...data, ...objekat };
      this.isLoading = true;

      this.klijent.post(`${routerpath}/api/Korisnik`, { ...data }).subscribe(
        (response) => {
          if (!!response) {
            timer(4000)
              .pipe(take(1))
              .subscribe(() => {
                this.isLoading = false;
                this.snackbar.open('Korisnik uspjesno dodan', 'X', {
                  duration: 3000,
                  panelClass: ['success-snack'],
                });
                this.dialogref.close();
              });
          } else {
            this.snackbar.open('Greska kod dodavanja', 'X', {
              duration: 3000,
              panelClass: ['error-snack'],
            });
            this.isLoading = false;
          }
        },
        (error) => {
          console.error('Error:', error);
          this.snackbar.open('Greska kod dodavanja', 'X', {
            duration: 3000,
            panelClass: ['error-snack'],
          });
          this.isLoading = false;
        }
      );
    } else {
      this.snackbar.open('Popunite ispravno svako polje', 'X', {
        duration: 3000,
        panelClass: ['error-snack'],
      });
    }
  }

  isWeakPassword(): boolean {
    return this.passwordStrength === 'Weak';
  }

  isMediumPassword(): boolean {
    return this.passwordStrength === 'Medium';
  }

  isStrongPassword(): boolean {
    return this.passwordStrength === 'Strong';
  }
}
