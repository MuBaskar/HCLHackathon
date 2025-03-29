import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import {HomePageComponent} from './home-page.component'
import {AuthGuard} from '../home-page/auth-service/auth.guard'

const routes: Routes = [


  //{path:'',component:HomePageComponent, canActivate: [AuthGuard] } 
  // Uncomment the above line to enable Auth guard

  {path:'',component:HomePageComponent}
  //free login to home page
  
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class HomePageModuleModule { }
