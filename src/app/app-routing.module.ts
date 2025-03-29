import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import {ForgotPasswordComponent} from './user-authentication/forgot-password/forgot-password.component'

const routes: Routes = [
  {path:'login',loadChildren: () => import('./user-authentication/user-authentication.module').then(m => m.UserAuthenticationModule) },
  {path:'home',loadChildren: () => import('./home-page/home-page.module').then(m => m.HomePageModuleModule) },  
  //{path:'forgot-password',component:ForgotPasswordComponent},
  { path: '', redirectTo: 'login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
