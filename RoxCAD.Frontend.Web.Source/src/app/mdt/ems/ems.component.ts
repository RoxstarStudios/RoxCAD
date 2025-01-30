
import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from '../../shared/navbar/navbar.component';
import { MdtTopbarComponent } from '../../shared/mdt-topbar/mdt-topbar.component';
import { MdtInfoType } from '../../types/mdt'
import { MdtLeaveModalComponent } from '../../shared/mdt-leave-modal/mdt-leave-modal.component';

@Component({
  selector: 'app-ems-page',
  standalone: true,
  imports: [NavbarComponent, MdtTopbarComponent, MdtLeaveModalComponent],
  templateUrl: './ems.component.html',
  styleUrl: './ems.component.css'
})
export class EmsComponent implements OnInit {
  mdtInfo: MdtInfoType = {
    type: "medical",
    divAbbr: "ems",
    divName: "Los Santos Medical Department",
    charName: "Chris D",
    charCallsign: "001"
  };

  mdtInfoStr = "";

  constructor() {
    this.mdtInfoStr = JSON.stringify(this.mdtInfo);
  }
  ngOnInit(): void {
    
  }
}
