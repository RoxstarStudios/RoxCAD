import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { NewComponent } from './new/new.component';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';

export const authRoutes: Routes = [
  {
    path: "",
    title: "Auth - RoxCAD",
    children: [
      {
        path: "login",
        title: "Login - RoxCAD",
        component: LoginComponent
      },
      {
        path: "new",
        title: "New Account - RoxCAD",
        component: NewComponent
      },
      {
        path: "pwreset",
        title: "Reset Password - RoxCAD",
        component: ResetpasswordComponent
      }
    ]
  }
];