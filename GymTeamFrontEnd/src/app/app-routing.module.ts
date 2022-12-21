import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {LandingPageComponent} from "./landing-page/landing-page.component";
import {LoginComponent} from "./landing-page/login/login.component";

const routes :Routes=[
  {path:'',component:LandingPageComponent},
  {path:'login',component:LoginComponent}

];

@NgModule({
  declarations: [],
  imports:
    [RouterModule.forRoot(routes)],
  exports:[RouterModule]
})
export class AppRoutingModule { }
