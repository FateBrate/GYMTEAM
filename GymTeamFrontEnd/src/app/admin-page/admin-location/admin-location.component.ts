import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Map } from 'mapbox-gl';
import * as mapboxgl from 'mapbox-gl';

import { routerpath } from 'src/app/constants/deafult';
import { MAPBOX_ACCESS_TOKEN } from 'src/app/service/mapbox.config';
@Component({
  selector: 'app-admin-location',
  templateUrl: './admin-location.component.html',
  styleUrls: ['./admin-location.component.css'],
})
export class AdminLocationComponent implements OnInit {
  locations: any;
  selectedLocation: any;
  showMore: boolean = false;
  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.GetLocations();
  }
  GetLocations(): void {
    console.log('radi');
    this.httpClient.get(routerpath + '/api/Lokacija').subscribe((res) => {
      if (!!res) this.locations = res;
    });
  }
  getImage(id: number) {
    return `${routerpath}/api/Lokacija/GetSlikaById?id=${id}`;
  }
  openClose() {
    this.showMore = !this.showMore;
  }
  viewMore(id: number) {
    this.openClose();
    this.httpClient
      .get(`${routerpath}/api/Lokacija/GetbyId?id=${id}`)
      .subscribe((res) => {
        if (!!res) {
          this.selectedLocation = res;
          const longitude = this.selectedLocation.longitude;
          const latitude = this.selectedLocation.latitude;

          const map = new Map({
            accessToken: MAPBOX_ACCESS_TOKEN,
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v11',
            center: [longitude, latitude],
            zoom: 12,
          });
          const marker = new mapboxgl.Marker()
            .setLngLat([longitude, latitude])
            .addTo(map);
        }
      });
  }
}
