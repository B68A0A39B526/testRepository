import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { PatientRoutingModule } from './patient-routing.module';
import { MatTableModule } from '@angular/material/table';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PatientRoutingModule,
    MaterialModule,
    MatTableModule
  ]
})
export class PatientModule { }
