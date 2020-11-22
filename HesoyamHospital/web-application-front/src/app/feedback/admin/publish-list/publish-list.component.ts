import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../../services/feedback.service';
import { Feedback } from '../../services/feedback.service';

@Component({
  selector: 'app-publish-list',
  templateUrl: './publish-list.component.html',
  styleUrls: ['./publish-list.component.css']
})

export class PublishListComponent implements OnInit {

  displayButton = true;  
  displayText = false;
  public element_data: Feedback[] = []; 
  displayedColumns: string[] = ['id', 'name', 'text', 'public'];
  public dataSource: Feedback[] = [];

  constructor(private _feedbackService: FeedbackService) { }

  ngOnInit(): void {
    this._feedbackService.getUnpublishedFeedbacks().subscribe((data) => this.dataSource = data);
  }


  public OnClick(element) {
    element.public = false;
    element.published = true;
    this.displayText = true;
    alert("Feedback id: " + element.id);
    this._feedbackService.publishFeedback(element.id).subscribe();
  }

}
