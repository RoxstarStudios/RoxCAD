
import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from '../../shared/navbar/navbar.component';
import { MdtTopbarComponent } from '../../shared/mdt-topbar/mdt-topbar.component';
import { MdtInfoType } from '../../types/mdt'
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-police-page',
  standalone: true,
  imports: [CommonModule, NavbarComponent, MdtTopbarComponent],
  templateUrl: './leo.component.html',
  styleUrl: './leo.component.css'
})
export class LawComponent implements OnInit {
  mdtInfo: MdtInfoType = {
    type: "police",
    divAbbr: "lspd",
    divName: "Los Santos Police Department",
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
