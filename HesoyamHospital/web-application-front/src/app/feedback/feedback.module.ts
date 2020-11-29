import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeedbackRoutingModule } from './feedback-routing.module';
import { PatientModule } from './patient/patient.module';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  imports: [
    CommonModule,
    FeedbackRoutingModule,
    PatientModule,
    HttpClientModule
  ],
  declarations: []
})
export class FeedbackModule { }
