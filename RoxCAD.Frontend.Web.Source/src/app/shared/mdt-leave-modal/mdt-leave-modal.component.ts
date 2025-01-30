import { CommonModule, NgClass } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MdtServicesService } from '../mdt-services.service';

@Component({
  selector: 'app-mdt-leave-modal',
  standalone: true,
  imports: [CommonModule, NgClass],
  templateUrl: './mdt-leave-modal.component.html',
  styleUrl: './mdt-leave-modal.component.css'
})
export class MdtLeaveModalComponent implements OnInit {
  modalActive: boolean = false;

  constructor(private mdtServices: MdtServicesService) {}

  ngOnInit(): void {
    this.mdtServices.subscribeLeaveModal((res: any) => {
      this.modalActive = true;
    });

    (document.querySelectorAll('.mdt-leave-modal-background') || []).forEach(($close) => {
      $close.addEventListener('click', () => {
        this.doNothing_HideModal();
      });
    });
  }

  goOffDuty_ChangeDivision_HideModal(): void {
    this.doNothing_HideModal();
  }

  goOffDuty_ReturnHome_HideModal(): void {
    this.doNothing_HideModal();
  }

  doNothing_HideModal(): void {
    this.modalActive = false;
  }
}
