import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { DocumentsRoutingModule } from './documents-routing.module';
import { PatientModule } from '../feedback/patient/patient.module';


@NgModule({
  imports: [
    CommonModule,
    DocumentsRoutingModule,
    PatientModule,
    HttpClientModule
  ]
})
export class DocumentsModule { }
