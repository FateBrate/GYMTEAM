import { Component, Inject, inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IUser } from 'src/app/service/models/user';

@Component({
  selector: 'app-employeedata',
  templateUrl: './employeedata.component.html',
  styleUrls: ['./employeedata.component.css'],
})
export class EmployeedataComponent implements OnInit {
  radnik: Partial<IUser>;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public popUpRef: MatDialogRef<EmployeedataComponent>
  ) {
    this.radnik = data.korisnik;
    console.log(this.radnik);
  }
  changetype: boolean = true;

  ngOnInit(): void {}
}
