import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { PublishListComponent } from './publish-list/publish-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { SurveysAndSectionsComponent } from './surveys-and-sections/surveys-and-sections.component';
import { FormsModule } from '@angular/forms';
import {MatDividerModule} from '@angular/material/divider';
import { SurveysResultsComponent } from './surveys-results/surveys-results.component';
import { SurveysDoctorsComponent } from './surveys-doctors/surveys-doctors.component';

@NgModule({
  declarations: [PublishListComponent, SurveysAndSectionsComponent, SurveysResultsComponent, SurveysDoctorsComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatTableModule,
    MatButtonModule,
    MaterialModule,
    FormsModule,
    MatDividerModule
  ]
})
export class AdminModule { }
