import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { LoginComponent } from './landing-page/login/login.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AdminHomeComponent } from './admin-page/admin-home/admin-home.component';
import { AdminInfoComponent } from './admin-page/admin-info/admin-info.component';

const routes: Routes = [
  { path: '', component: LandingPageComponent },
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
    ],
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
