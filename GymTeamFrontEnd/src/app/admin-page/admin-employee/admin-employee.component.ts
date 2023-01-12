import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { from } from 'rxjs';
import { AdminInfoComponent } from '../admin-info/admin-info.component';
import { AddUserComponent } from './add-user/add-user.component';
import { EmployeedataComponent } from './employeedata/employeedata.component';

@Component({
  selector: 'app-admin-employee',
  templateUrl: './admin-employee.component.html',
  styleUrls: ['./admin-employee.component.css'],
})
export class AdminEmployeeComponent implements OnInit {
  ime: string = '';
  prezime: string = '';
  lokacijaid: number = 0;
  employee: any;
  api_url: string = 'http://localhost:5164';
  constructor(
    private httpClient: HttpClient,
    private snackbar: MatSnackBar,
    private dialogRef: MatDialog
  ) {}

  ngOnInit(): void {
    this.FetchEmployees();
  }

  FetchEmployees(): void {
    console.log('hahah');
    this.httpClient.get(this.api_url + '/api/Korisnik').subscribe((x) => {
      this.employee = x;
    });
  }
  Obrisi(id: number): void {
    try {
      this.httpClient
        .delete(`${this.api_url}/api/Korisnik?id=${id}`)
        .subscribe((res) => {
          if (res) this.FetchEmployees();
        });
    } catch (error) {
      console.error(error);
    } finally {
      this.snackbar.open('Korisnik uspjesno obrisan', 'X', {
        duration: 3000,
        panelClass: ['cacin-caca'],
      });
    }
  }
  openForm(korisnik: any): void {
    this.dialogRef.open(EmployeedataComponent, {
      data: { korisnik },
      panelClass: ['formica'],
    });
  }
  openAddUserForm(): void {
    this.dialogRef
      .open(AddUserComponent, {
        panelClass: ['addUser'],
      })
      .afterClosed()
      .subscribe(() => this.FetchEmployees());
  }
}
