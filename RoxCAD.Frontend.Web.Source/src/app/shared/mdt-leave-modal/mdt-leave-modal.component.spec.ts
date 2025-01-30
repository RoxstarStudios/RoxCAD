import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MdtLeaveModalComponent } from './mdt-leave-modal.component';

describe('MdtLeaveModalComponent', () => {
  let component: MdtLeaveModalComponent;
  let fixture: ComponentFixture<MdtLeaveModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MdtLeaveModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MdtLeaveModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
