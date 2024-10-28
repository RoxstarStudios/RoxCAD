import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AxiosService {
  private axiosInstance = axios.create();

  get(url: string) {
    return this.axiosInstance.get(url);
  }

  validateAPI(): Promise<AxiosResponse<any, any>> {
    return this.get('/api');
  }

  validateWS(): Promise<AxiosResponse<any, any>> {
    return this.get('/ws');
  }
}
