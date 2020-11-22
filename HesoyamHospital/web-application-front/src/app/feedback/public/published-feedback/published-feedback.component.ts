import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../../services/feedback.service';
import { Feedback } from '../../services/feedback.service';


@Component({
  selector: 'app-published-feedback',
  templateUrl: './published-feedback.component.html',
  styleUrls: ['./published-feedback.component.css']
})
export class PublishedFeedbackComponent implements OnInit {
  
  public feedback: Feedback[] = [];

  constructor(private _feedbackService: FeedbackService) { }

  ngOnInit(): void {
    this._feedbackService.getPublishedFeedbacks().subscribe((data) => this.feedback = data);
  }
}
