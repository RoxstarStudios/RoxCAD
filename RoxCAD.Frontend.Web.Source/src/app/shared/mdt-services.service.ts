import { Injectable } from '@angular/core';
import { Subject, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MdtServicesService {
  leaveModal = new Subject();
  
  constructor() { }

  subscribeLeaveModal(onNext: any): Subscription {
    return this.leaveModal.subscribe(onNext);
  }

  showLeaveModal() {
    this.leaveModal.next(true);
  }
}
