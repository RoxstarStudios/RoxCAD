import { Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { authRoutes } from './auth/auth.routes';

export const appRoutes: Routes = [
    {
        path: "",
        title: "Home - RoxCAD",
        component: HomeComponent,
        children: [
            {
                path: "about",
                title: "About - RoxCAD",
                component: HomeComponent
            }
        ]
    },
    {
        path: "auth",
        children: authRoutes
    },
    {
        path: "**",
        redirectTo: "/",
        pathMatch: 'full'
    }
];
