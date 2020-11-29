import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveysDoctorsComponent } from './surveys-doctors.component';

describe('SurveysDoctorsComponent', () => {
  let component: SurveysDoctorsComponent;
  let fixture: ComponentFixture<SurveysDoctorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SurveysDoctorsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SurveysDoctorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
