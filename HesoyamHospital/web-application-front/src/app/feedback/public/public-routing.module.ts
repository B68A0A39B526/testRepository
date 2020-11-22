import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublishedFeedbackComponent } from './published-feedback/published-feedback.component'

const routes: Routes = [
  { path: 'allFeedback', component: PublishedFeedbackComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule { }
export const routingComponents = [ PublishedFeedbackComponent ]