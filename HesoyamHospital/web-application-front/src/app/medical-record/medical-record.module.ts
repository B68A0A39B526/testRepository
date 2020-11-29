import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShowMedicalRecordComponent } from './show-medical-record/show-medical-record.component';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/shared/material/material.module';



@NgModule({
  declarations: [ShowMedicalRecordComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
    
  ]
})
export class MedicalRecordModule { }
