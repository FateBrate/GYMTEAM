import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth/auth.service';
import { IUser } from 'src/app/service/models/user';
import { DataService } from 'src/app/service/data.service';
import { take, timer } from 'rxjs';
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
  isLoading: boolean = false;

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
      this.isLoading = true; // Set isLoading to true

      this.authService.login({ email, lozinka }).subscribe(
        (loggedIn) => {
          if (loggedIn) {
            // Simulate a delay of 2 seconds before navigating to another page
            timer(4000)
              .pipe(take(1))
              .subscribe(() => {
                this.router.navigate(['admin/home']);
                this.dataService.updateKorisnik();
              });
          } else {
            this.snackbar.open('Neispravni podaci za prijavu', 'X', {
              duration: 1000,
              panelClass: ['error-snack'],
            });
          }
          // Set isLoading to false after login request completes
        },
        (error) => {
          console.error('Login failed:', error);
          this.snackbar.open('Greška prilikom prijave', 'X', {
            duration: 1000,
            panelClass: ['error-snack'],
          });
          // Set isLoading to false if login request fails
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
