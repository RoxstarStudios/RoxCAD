
import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from '../../shared/navbar/navbar.component';
import { MdtTopbarComponent } from '../../shared/mdt-topbar/mdt-topbar.component';
import { MdtInfoType } from '../../types/mdt'

@Component({
  selector: 'app-fire-page',
  standalone: true,
  imports: [NavbarComponent, MdtTopbarComponent],
  templateUrl: './fire.component.html',
  styleUrl: './fire.component.css'
})
export class FireComponent implements OnInit {
  mdtInfo: MdtInfoType = {
    type: "fire",
    divAbbr: "safr",
    divName: "Blaine County Fire Department",
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
