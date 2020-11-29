import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { PostFeedbackComponent } from './post-feedback/post-feedback.component';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { FormsModule } from '@angular/forms';
import { SimpleSearchComponent } from './simple-search/simple-search.component';
import {MatCheckboxModule} from '@angular/material/checkbox'; 
import {MatDatepickerModule} from '@angular/material/datepicker'; 



@NgModule({
  declarations: [PostFeedbackComponent, SimpleSearchComponent],
  imports: [
    CommonModule,
    PatientRoutingModule,
    MaterialModule,
    FormsModule,
    MatCheckboxModule,
    MatDatepickerModule
  ]
})
export class PatientModule { }
