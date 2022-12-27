import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { LoginComponent } from './landing-page/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { SideMenuComponent } from './admin-page/side-menu/side-menu.component';
import { AdminHomeComponent } from './admin-page/admin-home/admin-home.component';
import { AdminInfoComponent } from './admin-page/admin-info/admin-info.component';
@NgModule({
  declarations: [AppComponent, LandingPageComponent, LoginComponent, AdminPageComponent, SideMenuComponent, AdminHomeComponent, AdminInfoComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
