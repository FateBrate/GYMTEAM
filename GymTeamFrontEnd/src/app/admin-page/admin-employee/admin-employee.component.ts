import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { from } from 'rxjs';
import { AdminInfoComponent } from '../admin-info/admin-info.component';
import { AddUserComponent } from './add-user/add-user.component';
import { EmployeedataComponent } from './employeedata/employeedata.component';
import { routerpath } from 'src/app/constants/deafult';

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
  ime_prezime: string = '';
  constructor(
    private httpClient: HttpClient,
    private snackbar: MatSnackBar,
    private dialogRef: MatDialog
  ) {}

  ngOnInit(): void {
    this.FetchEmployees(this.ime_prezime);
  }
  Filtriraj() {
    this.FetchEmployees(this.ime_prezime);
  }
  FetchEmployees(ime_prezime?: string): void {
    this.httpClient
      .get(`${routerpath}/api/Korisnik?ime_prezime=${ime_prezime}`)
      .subscribe((res) => {
        if (!!res) this.employee = res;
      });
  }
  Obrisi(id: number): void {
    try {
      this.httpClient
        .delete(`${routerpath}/api/Korisnik?id=${id}`)
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
  getSliku(id: number) {
    return `${routerpath}/api/Korisnik/GetSlikaById?id=${id}`;
  }
}
