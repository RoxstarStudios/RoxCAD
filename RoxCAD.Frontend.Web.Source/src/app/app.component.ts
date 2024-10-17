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

  pageLoaded = signal(false);

  payloadValid = environment.production ? signal(false) : signal(true);

  ngOnInit(): void {
    this.axiosService.get("/").then((res) => {
      const payloadHeader = res.headers["x-roxcad-payload"];

      if (payloadHeader) {
        try {
          const parsedPayload = JSON.parse(payloadHeader);

          if (Object.keys(parsedPayload).every((key) => typeof key === "string" && typeof parsedPayload[key] === "string")) {
            console.log("Valid Payload Header");
            this.payloadValid.set(true);
          } else {
            console.log("Invalid Payload Format");
            this.payloadValid.set(false);
          }
        } catch {
          console.log("Payload is not a valid JSON string");
          this.payloadValid.set(false);
        }
      } else {
        console.log("No Payload Header.");
        this.payloadValid.set(environment.production ? false : true);
      }
    }).then(() => {
      this.pageLoaded.set(true);
    });
  }
}
