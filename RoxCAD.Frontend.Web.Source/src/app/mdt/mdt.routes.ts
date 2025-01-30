import { Routes } from '@angular/router';
import { LawComponent } from './leo/leo.component';
import { FireComponent } from './fire/fire.component';
import { EmsComponent } from './ems/ems.component';

export const mdtRoutes: Routes = [
  {
    path: "",
    title: "MDT - RoxCAD",
    children: [
      {
        path: "leo",
        title: "Law Enforcement - RoxCAD",
        component: LawComponent
      },
      {
        path: "fire",
        title: "Fire & Rescue - RoxCAD",
        component: FireComponent
      },
      {
        path: "ems",
        title: "Medical Service - RoxCAD",
        component: EmsComponent
      }
    ]
  }
];