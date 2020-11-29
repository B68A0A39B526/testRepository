import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveysResultsComponent } from './surveys-results.component';

describe('SurveysResultsComponent', () => {
  let component: SurveysResultsComponent;
  let fixture: ComponentFixture<SurveysResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SurveysResultsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SurveysResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
