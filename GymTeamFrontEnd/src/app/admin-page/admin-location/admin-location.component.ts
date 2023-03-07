import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-location',
  templateUrl: './admin-location.component.html',
  styleUrls: ['./admin-location.component.css'],
})
export class AdminLocationComponent implements OnInit {
  api_url: string = 'http://localhost:5164';
  lokacija: any;
  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    //  this.fetchLokacije();
  }
  // fetchLokacije(): void {
  //   console.log('radi');
  //   this.httpClient.get(this.api_url + '/api/Lokacija').subscribe((x) => {
  //     this.lokacija = x;
  //   });
  // }
}
