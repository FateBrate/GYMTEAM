import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IUser } from 'src/app/service/models/user';
import { Uloga, getRoleName } from 'src/app/service/models/role';
import { routerpath } from 'src/app/constants/deafult';
@Component({
  selector: 'app-employeedata',
  templateUrl: './employeedata.component.html',
  styleUrls: ['./employeedata.component.css'],
})
export class EmployeedataComponent implements OnInit {
  radnik: Partial<IUser>;
  uloga: Uloga | undefined;
  ulogaString: string = '';

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public popUpRef: MatDialogRef<EmployeedataComponent>
  ) {
    this.radnik = data.korisnik;
    this.uloga = this.radnik.roleId as Uloga;
    this.ulogaString = getRoleName(this.uloga);
  }
  changetype: boolean = true;

  ngOnInit(): void {
    if (this.radnik && this.radnik.id) {
      this.getSliku(this.radnik.id);
    }
  }

  getSliku(id: number) {
    return `${routerpath}/api/Korisnik/GetSlikaById?id=${id}`;
  }
}
