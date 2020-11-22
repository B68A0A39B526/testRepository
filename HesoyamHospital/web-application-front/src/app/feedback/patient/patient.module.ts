import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { PostFeedbackComponent } from './post-feedback/post-feedback.component';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [PostFeedbackComponent],
  imports: [
    CommonModule,
    PatientRoutingModule,
    MaterialModule,
    FormsModule
  ]
})
export class PatientModule { }
