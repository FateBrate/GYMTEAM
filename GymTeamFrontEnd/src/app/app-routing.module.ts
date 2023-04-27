import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { LoginComponent } from './landing-page/login/login.component';
import { AboutPageComponent } from './landing-page/about/about-page.component';
import { ShopPageComponent } from './landing-page/shop/shop-page.component';
import { LokacijePageComponent } from './landing-page/Lokacije/lokacije-page.component';
import { CjenovnikPageComponent } from './landing-page/Cjenovnik/cjenovnik-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AdminHomeComponent } from './admin-page/admin-home/admin-home.component';
import { AdminInfoComponent } from './admin-page/admin-info/admin-info.component';
import { AdminEmployeeComponent } from './admin-page/admin-employee/admin-employee.component';
import { AdminLocationComponent } from './admin-page/admin-location/admin-location.component';
import { PriceListComponent } from './admin-page/price-list/price-list.component';

const routes: Routes = [
  {
    path: '',
    component: LandingPageComponent,
    children: [
      {
        path: 'about',
        component: AboutPageComponent,
      },
      {
        path: 'shop',
        component: ShopPageComponent,
      },
      {
        path: 'lokacije',
        component: LokacijePageComponent,
      },
      {
        path: 'cjenovnik',
        component: CjenovnikPageComponent,
      },
    ],
  },
  { path: 'login', component: LoginComponent },
  {
    path: 'admin',
    component: AdminPageComponent,
    children: [
      {
        path: 'home',
        component: AdminHomeComponent,
      },
      {
        path: 'info',
        component: AdminInfoComponent,
      },
      {
        path: 'employee',
        component: AdminEmployeeComponent,
      },
      {
        path: 'locations',
        component: AdminLocationComponent,
      },
      {
        path: 'price-list',
        component: PriceListComponent,
      },
    ],
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
