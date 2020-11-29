import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveysAndSectionsComponent } from './surveys-and-sections.component';

describe('SurveysAndSectionsComponent', () => {
  let component: SurveysAndSectionsComponent;
  let fixture: ComponentFixture<SurveysAndSectionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SurveysAndSectionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SurveysAndSectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
