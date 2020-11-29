import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowMedicalRecordComponent } from './show-medical-record.component';

describe('ShowMedicalRecordComponent', () => {
  let component: ShowMedicalRecordComponent;
  let fixture: ComponentFixture<ShowMedicalRecordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowMedicalRecordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowMedicalRecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
