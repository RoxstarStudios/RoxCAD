import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MdtTopbarComponent } from './mdt-topbar.component';

describe('MdtTopbarComponent', () => {
  let component: MdtTopbarComponent;
  let fixture: ComponentFixture<MdtTopbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MdtTopbarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MdtTopbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
