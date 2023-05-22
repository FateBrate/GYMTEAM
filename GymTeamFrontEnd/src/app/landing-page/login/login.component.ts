import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth/auth.service';
import { IUser } from 'src/app/service/models/user';
import { DataService } from 'src/app/service/data.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  forma: FormGroup = new FormGroup({
    email: new FormControl(''),
    lozinka: new FormControl(''),
  });
  constructor(
    private authService: AuthService,
    private router: Router,
    private snackbar: MatSnackBar,
    private dataService: DataService
  ) {}
  ngOnInit(): void {}

  // loginUser({ email, lozinka }: Partial<IUser>) {
  //   if (!!email && !!lozinka) {
  //     this.authService.login({ email, lozinka });

  //     this.ruter.navigate(['admin/home']);
  //   } else {
  //     this.snackbar.open('Neispravni podaci za prijavu', 'X', {
  //       duration: 1000,
  //       panelClass: ['error-snack'],
  //     });
  //   }
  // }
  loginUser({ email, lozinka }: Partial<IUser>) {
    if (!!email && !!lozinka) {
      this.authService.login({ email, lozinka }).subscribe(
        (loggedIn) => {
          if (loggedIn) {
            this.router.navigate(['admin/home']);
            this.dataService.updateKorisnik();
          } else {
            this.snackbar.open('Neispravni podaci za prijavu', 'X', {
              duration: 1000,
              panelClass: ['error-snack'],
            });
          }
        },
        (error) => {
          console.error('Login failed:', error);
          this.snackbar.open('Greška prilikom prijave', 'X', {
            duration: 1000,
            panelClass: ['error-snack'],
          });
        }
      );
    } else {
      this.snackbar.open('Neispravni podaci za prijavu', 'X', {
        duration: 1000,
        panelClass: ['error-snack'],
      });
    }
  }
}
