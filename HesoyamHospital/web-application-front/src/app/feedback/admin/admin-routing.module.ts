import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublishListComponent } from './publish-list/publish-list.component';
import { MatTableModule } from '@angular/material/table';
import { SurveysAndSectionsComponent } from './surveys-and-sections/surveys-and-sections.component';

const routes: Routes = [
  { path: 'publishlist', component: PublishListComponent },
  { path: 'surveys-sections', component: SurveysAndSectionsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
export const routingComponents = [ PublishListComponent , SurveysAndSectionsComponent]