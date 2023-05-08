import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IUser } from 'src/app/service/models/user';
import { Uloga } from 'src/app/service/models/role';
@Component({
  selector: 'app-employeedata',
  templateUrl: './employeedata.component.html',
  styleUrls: ['./employeedata.component.css'],
})
export class EmployeedataComponent implements OnInit {
  radnik: Partial<IUser>;
  uloga: Uloga = 1;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public popUpRef: MatDialogRef<EmployeedataComponent>
  ) {
    this.radnik = data.korisnik;
  }
  changetype: boolean = true;

  ngOnInit(): void {}
}
