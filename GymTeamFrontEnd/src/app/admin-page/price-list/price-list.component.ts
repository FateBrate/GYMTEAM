import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { routerpath } from 'src/app/constants/deafult';

@Component({
  selector: 'app-price-list',
  templateUrl: './price-list.component.html',
  styleUrls: ['./price-list.component.css'],
})
export class PriceListComponent implements OnInit {
  priceList: any;
  showEdit: boolean = false;
  picked: any;
  planName: string = '';
  planDetails: string = '';
  planPrice: string = '';
  rows: number = 0;
  constructor(private httpClient: HttpClient, private snackbar: MatSnackBar) {}
  loadPriceList() {
    this.httpClient
      .get(routerpath + '/api/Cjenovnik/GetAll')
      .subscribe((res: any) => {
        if (!!res) {
          this.priceList = res;
        }
      });
  }
  editList(id: number) {
    this.httpClient
      .get(routerpath + '/api/Cjenovnik/GetById?id=' + id)
      .subscribe((res) => {
        if (!!res) {
          this.picked = res;
          this.planDetails =
            this.picked.opis.slice(0, 2) +
            this.picked.opis.slice(2).split('-').join('\n-');
          this.picked.opis = this.planDetails;
          this.rows = this.numberOfRows(this.picked.opis);
          console.log(this.rows);
        }
      });
  }
  show() {
    this.showEdit = !this.showEdit;
  }
  SaveChanges() {
    const body = {
      nazivStavke: this.picked.nazivStavke,
      opis: this.picked.opis.replace(/\n/g, ''),
      cijena: this.picked.cijena,
      korisnikId: 7,
    };
    let id = this.picked.id;
    this.httpClient
      .put(routerpath + '/api/Cjenovnik?id=' + id, body)
      .subscribe((res) => {
        if (!!res) {
          this.show();
          this.snackbar.open('Izmjene su ažurirane', 'X', {
            duration: 3000,
            panelClass: ['cacin-caca'],
          });
          this.loadPriceList();
        }
      });
  }
  numberOfRows(opis: string): number {
    let count = 0;
    for (let i = 0; i < opis.length; i++) {
      if (opis[i] === '-') count++;
    }
    return count;
  }
  ngOnInit() {
    this.loadPriceList();
  }
}
