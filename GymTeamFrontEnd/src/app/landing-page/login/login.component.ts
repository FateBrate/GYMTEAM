import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth/auth.service';
import { IUser } from 'src/app/service/models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  forma:FormGroup= new FormGroup({
    email:new FormControl(''),
    lozinka:new FormControl('')
  });
  constructor(private authService:AuthService) {
  }
  ngOnInit(): void {
  }


  loginUser({email,lozinka}:Partial<IUser>){
    if(!!email && !!lozinka){
      const loginUspjesan = this.authService.login({email,lozinka})
      if(loginUspjesan){

      }
    }
  }
}
