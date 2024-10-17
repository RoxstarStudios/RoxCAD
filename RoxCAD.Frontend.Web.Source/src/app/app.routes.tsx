import { Routes } from '@angular/router';
import React from 'react';
import { HomeComponent } from './views/home/home.component';

export const routes: Routes = [
    {
        path: "",
        title: "Home - RoxCAD",
        component: HomeComponent
    },
    {
        path: "**",
        redirectTo: "/",
        pathMatch: 'full'
    }
];
