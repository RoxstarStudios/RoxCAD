import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root'
})
export class AxiosService {
  private axiosInstance = axios.create();

  get(url: string) {
    return this.axiosInstance.get(url);
  }
}
