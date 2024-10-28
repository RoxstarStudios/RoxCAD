import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AxiosService } from './services/axios.service';
import { CommonModule } from '@angular/common';

import { environment } from './../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  constructor(private axiosService: AxiosService) { }

  envProdOverride: boolean = false;

  pageLoaded = signal(false);

  //webServerValid = environment.production ? signal(false) : signal(false);
  webServerValid = signal(true);

  async ngOnInit(): Promise<void> {
    if (environment.production) {
      await this.axiosService.validateAPI().then(
        async () => {
          // API check passed
          await this.axiosService.validateWS().then(
            () => {
              // WS check passed
              console.log("RoxCAD Loaded Successfully");
              this.webServerValid.set(true);
            },
            () => {
              // WS check failed, redirect or show error
              console.log("RoxCAD Failed to load.");
              this.webServerValid.set(false);
            }
          );
        },
        () => {
          // API check failed, redirect or show error
          console.log("RoxCAD Failed to load.");
          this.webServerValid.set(false);
        }
      ).finally(() => {
        this.pageLoaded.set(true);
      });
    }
  }
}
