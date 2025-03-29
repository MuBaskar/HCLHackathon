import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {UserService} from '../services/user.service'
import {UserModel} from '../Models/UserModel'
import { jwtDecode} from 'jwt-decode';

@Component({
  selector: 'app-user-authentication',
  templateUrl: './user-authentication.component.html',
  styleUrls: ['./user-authentication.component.css'],
  providers:[UserModel]
})
export class UserAuthenticationComponent {
  loginForm:any
  submitted = false;
  token:string=''
  tokenKey:string = 'authToken';

  constructor(private fb: FormBuilder, private service:UserService, private userModel: UserModel) {
    // Define form fields and validation rules
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],  // Required & must be a valid email
      password: ['', [Validators.required, Validators.minLength(6)]]  // Required & min length of 6
    });
  }
  
  get f() {
    return this.loginForm.controls;
  }

   onSubmit() {
    this.submitted = true;

    // Stop if the form is invalid
    if (this.loginForm.invalid) {
      return;
    }
debugger
this.userModel.email = this.loginForm.value.email
this.userModel.password = this.loginForm.value.password
this.service.login(this.userModel).subscribe((result:string)=>{
  debugger
  this.token = result
  localStorage.setItem(this.tokenKey, this.token)
})
    //console.log("Login Successful", this.loginForm.value);
    //alert("Login Successful!");
  }

  getDecodedToken(): any {
    const token = localStorage.getItem(this.tokenKey);
    if (token) {
      return jwtDecode(token);
    }
    return null;
  }

  getTokenExpiration(): Date | null {
    const decodedToken = this.getDecodedToken();
    if (decodedToken && decodedToken.exp) {
      return new Date(decodedToken.exp * 1000);  // Convert expiry time from seconds to milliseconds
    }
    return null;
  }

  getUsername(): string | null {
    const decodedToken = this.getDecodedToken();
    return decodedToken ? decodedToken.username || decodedToken.sub : null;
  }

  isTokenExpired(): boolean {
    const expiry = this.getTokenExpiration();
    return expiry ? new Date() > expiry : true;
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
  }
}
