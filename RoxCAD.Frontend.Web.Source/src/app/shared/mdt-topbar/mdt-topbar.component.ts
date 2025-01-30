
import { NgClass } from '@angular/common';
import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { MdtInfoType } from '../../types/mdt';
import { MdtServicesService } from '../mdt-services.service';

@Component({
  selector: 'app-mdt-topbar',
  standalone: true,
  imports: [NgClass],
  templateUrl: './mdt-topbar.component.html',
  styleUrl: './mdt-topbar.component.css'
})
export class MdtTopbarComponent implements OnInit {
  @Input() currentMdtInfo: string = "";

  dateTime: { day: string, time: string } = {
    day: "",
    time: ""
  }

  currentMdtInfoObj: MdtInfoType = {
    type: "police",
    divAbbr: "",
    divName: "",
    charName: "",
    charCallsign: ""
  }

  constructor(private mdtServices: MdtServicesService) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['currentMdtInfo']) {
      const newValue = changes['currentMdtInfo'].currentValue;

      if (newValue) {
        try {
          // Safely parse the input string if it exists and is valid
          this.currentMdtInfoObj = JSON.parse(newValue) as MdtInfoType;
        } catch (error) {
          console.error('Failed to parse currentMdtInfo:', error);
        }
      } else {
        console.warn('Received empty or null currentMdtInfo.');
      }
    }
  }

  ngOnInit(): void {
    this.dateTime = this.GetDateAndTime();
    
    setInterval(() => {
      this.dateTime = this.GetDateAndTime();
    }, 500)
  }

  OnLeaveModalActivate(): void {
    this.mdtServices.showLeaveModal();
  }

  GetDateAndTime(): { day: string, time: string } {
    const now: Date = new Date();

    const day: string = now.toUTCString().split(', ')[0];
    const time: string = now.toISOString().slice(11, 19);

    return { day, time };
  }
}
