import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserAuthenticationComponent } from './main/user-authentication.component'
import { UserAuthenticationRoutingModule } from './main/user-authentication-routing.module';  // Import routing module
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { ReactiveFormsModule } from '@angular/forms';
import {UserService} from '../user-authentication/services/user.service'
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    UserAuthenticationComponent,
    ForgotPasswordComponent,
    RegisterUserComponent
  ],
  imports: [
    CommonModule,
    UserAuthenticationRoutingModule  ,
    ReactiveFormsModule  ,
    HttpClientModule
  ],
  providers: [UserService],
})
export class UserAuthenticationModule { }
