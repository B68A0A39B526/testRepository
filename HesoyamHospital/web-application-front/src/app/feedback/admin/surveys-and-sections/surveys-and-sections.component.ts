import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../../services/feedback.service'
import { SurveyDTO } from '../../DTOs/survey-dto';

@Component({
  selector: 'app-surveys-and-sections',
  templateUrl: './surveys-and-sections.component.html',
  styleUrls: ['./surveys-and-sections.component.css']
})
export class SurveysAndSectionsComponent implements OnInit {

  public SurveyDTO=new SurveyDTO(1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1);
  public _AnswerOne;
  public _AnswerTwo;
  public _AnswerThree;
  public _AnswerFour;
  public _AnswerFive;
  public _AnswerSix;
  public _AnswerSeven;
  public _AnswerEight;
  public _AnswerNine;
  public _AnswerTen;
  public _AnswerEleven;
  public _AnswerTwelve;
  public _AnswerThirteen;
  public _AnswerFourteen;
  public _AnswerFifteen;
  public _AnswerSixteen;
  


  

  constructor(private _feedbackService: FeedbackService) { }
  

  ngOnInit(): void {
  }
  submit() {
    this.prepareSurvey()
    this._feedbackService.postSurvey(this.SurveyDTO).subscribe(
      (val) => {
        this.provideFeedback();
        
      });
    
    
  }
  provideFeedback(){
    alert("Your survey is successfully submited!");
  }
  prepareSurvey() {
   this.SurveyDTO.AnswerOne = this._AnswerOne == 0 ? 1 : this._AnswerOne == 1 ? 2 : this._AnswerOne == 2 ? 3 : this._AnswerOne == 3 ? 4 : 5;
   this.SurveyDTO.AnswerTwo = this._AnswerTwo == 0 ? 1 : this._AnswerTwo == 1 ? 2 : this._AnswerTwo == 2 ? 3 : this._AnswerTwo == 3 ? 4 : 5;
   this.SurveyDTO.AnswerThree = this._AnswerThree == 0 ? 1 : this._AnswerThree == 1 ? 2 : this._AnswerThree == 2 ? 3 : this._AnswerThree == 3 ? 4 : 5;
   this.SurveyDTO.AnswerFour = this._AnswerFour == 0 ? 1 : this._AnswerFour == 1 ? 2 : this._AnswerFour == 2 ? 3 : this._AnswerFour == 3 ? 4 : 5;
   this.SurveyDTO.AnswerFive = this._AnswerFive == 0 ? 1 : this._AnswerFive == 1 ? 2 : this._AnswerFive == 2 ? 3 : this._AnswerFive == 3 ? 4 : 5;
   this.SurveyDTO.AnswerSix = this._AnswerSix == 0 ? 1 : this._AnswerSix == 1 ? 2 : this._AnswerSix == 2 ? 3 : this._AnswerSix == 3 ? 4 : 5;
   this.SurveyDTO.AnswerSeven = this._AnswerSeven== 0 ? 1 : this._AnswerSeven == 1 ? 2 : this._AnswerSeven == 2 ? 3 : this._AnswerSeven == 3 ? 4 : 5;
   this.SurveyDTO.AnswerEight = this._AnswerEight == 0 ? 1 : this._AnswerEight == 1 ? 2 : this._AnswerEight == 2 ? 3 : this._AnswerEight == 3 ? 4 : 5;
   this.SurveyDTO.AnswerNine = this._AnswerNine == 0 ? 1 : this._AnswerNine == 1 ? 2 : this._AnswerNine == 2 ? 3 : this._AnswerNine == 3 ? 4 : 5;
   this.SurveyDTO.AnswerTen = this._AnswerTen == 0 ? 1 : this._AnswerTen == 1 ? 2 : this._AnswerTen == 2 ? 3 : this._AnswerTen == 3 ? 4 : 5;
   this.SurveyDTO.AnswerEleven = this._AnswerEleven == 0 ? 1 : this._AnswerEleven == 1 ? 2 : this._AnswerEleven == 2 ? 3 : this._AnswerEleven == 3 ? 4 : 5;
   this.SurveyDTO.AnswerTwelve = this._AnswerTwelve == 0 ? 1 : this._AnswerTwelve == 1 ? 2 : this._AnswerTwelve == 2 ? 3 : this._AnswerTwelve == 3 ? 4 : 5;
   this.SurveyDTO.AnswerThirteen = this._AnswerThirteen == 0 ? 1 : this._AnswerThirteen == 1 ? 2 : this._AnswerThirteen == 2 ? 3 : this._AnswerThirteen == 3 ? 4 : 5;
   this.SurveyDTO.AnswerFourteen = this._AnswerFourteen == 0 ? 1 : this._AnswerFourteen == 1 ? 2 : this._AnswerFourteen == 2 ? 3 : this._AnswerFourteen == 3 ? 4 : 5;
   this.SurveyDTO.AnswerFifteen = this._AnswerFifteen == 0 ? 1 : this._AnswerFifteen == 1 ? 2 : this._AnswerFifteen == 2 ? 3 : this._AnswerFifteen == 3 ? 4 : 5;
   this.SurveyDTO.AnswerSixteen = this._AnswerSixteen == 0 ? 1 : this._AnswerSixteen == 1 ? 2 : this._AnswerSixteen == 2 ? 3 : this._AnswerSixteen == 3 ? 4 : 5;

  }


}
