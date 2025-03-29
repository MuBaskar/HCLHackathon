import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UserAuthenticationComponent } from '../main/user-authentication.component';
import { ForgotPasswordComponent } from '../forgot-password/forgot-password.component';
import { RegisterUserComponent } from '../register-user/register-user.component';

const routes: Routes = [
  {  path: '', component: UserAuthenticationComponent  },
  // This will be the default route for /login
  { path: 'forgot-password', component: ForgotPasswordComponent  },
  { path: 'register-user', component: RegisterUserComponent  }

  // This will map to /login/forgot-password
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAuthenticationRoutingModule { }
