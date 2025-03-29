import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
//import {ForgotPasswordComponent} from './user-authentication/forgot-password/forgot-password.component'

@NgModule({
  declarations: [
    AppComponent,
    //ForgotPasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent] 
})
export class AppModule { }
