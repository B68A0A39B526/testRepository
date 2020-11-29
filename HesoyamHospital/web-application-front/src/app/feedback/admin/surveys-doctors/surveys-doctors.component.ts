import { Component, OnInit } from '@angular/core';
import { DoctorDTO } from '../../services/feedback.service';
import { SectionDTO } from '../../services/feedback.service';
import { FeedbackService } from '../../services/feedback.service';

@Component({
  selector: 'app-surveys-doctors',
  templateUrl: './surveys-doctors.component.html',
  styleUrls: ['./surveys-doctors.component.css']
})
export class SurveysDoctorsComponent implements OnInit {

  displayedColumns2: string[] = ['questionOne', 'questionTwo', 'questionThree', 'questionFour'];
  displayedColumns: string[] = ['questionOne', 'questionTwo', 'questionThree', 'public'];
  public dataSource: DoctorDTO[] = [];
  public sections : SectionDTO[] = [];

  constructor(private _feedbackService: FeedbackService) { }

  ngOnInit(): void {
    this._feedbackService.getAllDoctors().subscribe((data) => this.dataSource=data);
  }

  public OnClick(element) {
   
    this._feedbackService.getDoctorsSectionsById(element.id).subscribe((data) => this.sections=data);
  }
}
