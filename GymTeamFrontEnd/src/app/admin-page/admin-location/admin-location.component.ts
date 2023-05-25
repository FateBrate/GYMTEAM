import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
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
  openNew: boolean = false;
  name: string = '';
  photo: any;
  latitude: number = 0;
  longitude: number = 0;

  constructor(private httpClient: HttpClient, private snackbar: MatSnackBar) {}

  ngOnInit(): void {
    this.GetLocations();
  }
  GetLocations(): void {
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
  onFileChange(event: any) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.photo = reader.result;
      };
    }
  }
  addNew() {
    this.openNew = true;

    setTimeout(() => {
      const map = new Map({
        accessToken: MAPBOX_ACCESS_TOKEN,
        container: 'mapAdd',
        style: 'mapbox://styles/mapbox/streets-v11',
        center: [17.8357, 44.1623],
        zoom: 12,
      });
      const clickListener = (e: any) => {
        this.latitude = e.lngLat.lat;
        this.longitude = e.lngLat.lng;

        const marker = new mapboxgl.Marker()
          .setLngLat([this.longitude, this.latitude])
          .addTo(map);

        map.off('click', clickListener);
      };

      map.on('click', clickListener);
    }, 0);
  }
  saveChanges() {
    const body = {
      naziv: this.name,
      adresaId: 2,
      latitude: this.latitude,
      longitude: this.longitude,
      slika: this.photo,
    };
    this.httpClient
      .post(routerpath + '/api/Lokacija', body)
      .subscribe((res) => {
        if (!!res) {
          console.log(res);
          this.snackbar.open('Uspjesno dodana nova lokacija', 'X', {
            duration: 3000,
            panelClass: ['success-snack'],
          });
          this.openNew = false;
          this.GetLocations();
        }
      });
  }
  deleteLocation(id: number) {
    const confirmed = confirm(
      'Da li ste sigurni da želite obrisati ovu lokaciju?'
    );
    if (!confirmed) {
      return;
    }

    this.httpClient
      .delete(`${routerpath}/api/Lokacija?id=${id}`)
      .subscribe((res) => {
        if (!!res) {
          this.GetLocations();
          this.openClose();
          this.snackbar.open('Uspjesno obrisana lokacija', 'X', {
            duration: 3000,
            panelClass: ['success-snack'],
          });
        }
      });
  }
}
