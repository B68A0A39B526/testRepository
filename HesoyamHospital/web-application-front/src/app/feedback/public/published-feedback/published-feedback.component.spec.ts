import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublishedFeedbackComponent } from './published-feedback.component';

describe('PublishedFeedbackComponent', () => {
  let component: PublishedFeedbackComponent;
  let fixture: ComponentFixture<PublishedFeedbackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublishedFeedbackComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PublishedFeedbackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
