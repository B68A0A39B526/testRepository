import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SurveyRoutingModule } from './survey-routing.module';
import { SurveyFormComponent } from './survey-form/survey-form.component';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [SurveyFormComponent],
  imports: [
    CommonModule,
    SurveyRoutingModule,
    MaterialModule,
    FormsModule
    
  ]
})
export class SurveyModule { }
